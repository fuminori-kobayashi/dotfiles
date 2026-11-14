# 個人用設定ファイル

macOS、Linux、WSL (Ubuntu)、Windows の MSYS2 で使う。MSYS2 で使うときは [MSYS2.md](MSYS2.md) を参照。

| パス | 置き場所 | 内容 |
| --- | --- | --- |
| `.emacs.d/init.el` | `~/.emacs.d/init.el` | Emacs の設定 |
| `.tmux.conf` | `~/.tmux.conf` | tmux の設定 |
| `claude/` | `~/.local/bin/`、`~/.claude/` | Claude Code のプロンプトを Emacs で編集する設定（[README](claude/README.md)） |
| `windows/` | `~/.local/bin/` | WSL / MSYS2 の tmux でペインを移動したら IME を OFF にするツール（[README](windows/README.md)） |
| `javascript/` | 各プロジェクトのルート | ESLint / Prettier の設定の雛形（[README](javascript/README.md)） |

## 前提

- Emacs 27.2 以降。MELPA のパッケージ（`web-mode`、`flycheck`、`prettier-js`、`company`、`copilot` など）と ripgrep が要る。
- tmux 3.2 以降。prefix は `C-j`（下の表）。Linux (X11) ではマウス選択がクリップボードにコピーされない。
- Betterleaks（pre-commit フックで使う）。`brew install betterleaks` で入れる。
  Linux / WSL は [Homebrew on Linux](https://docs.brew.sh/Homebrew-on-Linux) を入れ、`brew shellenv` の行を `~/.bashrc` などに足して PATH を通しておく。

## tmux のキーバインド

標準から変えているもの。日本語入力のままでも移動できるように、移動は Ctrl を押したままのキーにしている。
ペインを移動すると、macOS では入力ソースが ABC に、WSL と MSYS2 では IME が OFF に、Linux (IBus + Mozc) では英字入力になる。

| キー | 動作 | 標準 |
| --- | --- | --- |
| `C-j` | prefix | `C-b` |
| `C-j C-o` | 次のペインへ移動 | `C-j o`（`C-o` は rotate-window） |
| `C-j C-n` | 次のウィンドウへ移動 | `C-j n` |
| `C-j C-l` | rotate-window（ペインの並びを回す） | `C-j C-o` |

API キーなどの秘密情報は `.env` や `*.local` に分ける（`.gitignore` で除外している）。
clone したら `git config core.hooksPath githooks` を実行し、コミット時に Betterleaks で機密情報を調べる pre-commit フックを有効にする。
