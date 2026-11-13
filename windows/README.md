# Windows 用の小さなツール

| ファイル | 置き場所 | 内容 |
| --- | --- | --- |
| `ime-off.cs` | `~/.local/bin/ime-off.exe`（ビルドして置く） | 前面のウィンドウの IME を OFF にする。WSL の tmux でペインを移動したときに呼ぶ |

## ビルド

Windows に最初から入っている .NET Framework の `csc.exe` でビルドする。Visual Studio などは要らない。
WSL では、リポジトリのルートで次を実行する。

```sh
/mnt/c/Windows/Microsoft.NET/Framework64/v4.0.30319/csc.exe /nologo \
  /out:"$(wslpath -w ~/.local/bin/ime-off.exe)" "$(wslpath -w windows/ime-off.cs)"
chmod +x ~/.local/bin/ime-off.exe
```

`.tmux.conf` は `~/.local/bin/ime-off.exe` があるときだけ hook を登録するので、ビルドしたあとで `tmux source ~/.tmux.conf` を実行する。

## 補足

- 前面のウィンドウ（tmux を開いている Windows Terminal）の IME ウィンドウに `WM_IME_CONTROL` / `IMC_SETOPENSTATUS` を送って OFF にする。
- 起動にかかるのは 70ms ほどで、tmux からは `run-shell -b` で呼ぶので、ペインの移動は待たされない。
- `/etc/wsl.conf` で `appendWindowsPath = false` にしていても動くように、`csc.exe` はフルパスで呼ぶ。
