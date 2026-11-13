// 前面のウィンドウ（tmux を開いている Windows Terminal）の IME を OFF にする。
// WSL / MSYS2 の tmux で、ペインを移動したときに呼ぶ（.tmux.conf の after-select-pane）。
// Windows に最初から入っている .NET Framework の csc.exe でビルドする（windows/README.md）。
using System;
using System.Runtime.InteropServices;

class ImeOff {
  [DllImport("user32.dll")] static extern IntPtr GetForegroundWindow();
  [DllImport("imm32.dll")] static extern IntPtr ImmGetDefaultIMEWnd(IntPtr hWnd);
  [DllImport("user32.dll")] static extern IntPtr SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

  const uint WM_IME_CONTROL = 0x283;
  const int IMC_SETOPENSTATUS = 0x6;

  static int Main() {
    IntPtr ime = ImmGetDefaultIMEWnd(GetForegroundWindow());
    if (ime == IntPtr.Zero) return 1;
    SendMessage(ime, WM_IME_CONTROL, (IntPtr)IMC_SETOPENSTATUS, IntPtr.Zero);
    return 0;
  }
}
