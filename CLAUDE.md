# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Overview

YtDlpGUI is a small Windows Forms front-end (.NET 10, `net10.0-windows`, nullable + implicit usings enabled) that runs `yt-dlp` for a URL. See `README.md` for usage. There are no tests and no linter config beyond `.editorconfig`. The repo is on GitHub (`nemethviktor/yt-dlp-gui`, branch `main`), with releases tagged `v1.0.<build>`.

## Commands

- Build: `dotnet build YtDlpGUI.csproj`
- Run: `dotnet run --project YtDlpGUI.csproj`
- Release: `dotnet build -c Release` also publishes (the `PublishAfterBuild` target in the csproj) a self-contained single-file `YtDlpGUI.exe` to `...\bin\Release\net10.0-windows\win-x64\publish\`. The target is skipped under an explicit `dotnet publish`, and the Release-only properties (win-x64, self-contained, single-file) live in the csproj. The target framework is plain `net10.0-windows` to avoid the unused 27 MB Windows SDK projection DLL.

Build output does **not** go to `bin\`/`obj\` in the repo. `Directory.Build.props` redirects it to `%LOCALAPPDATA%\build\YtDlpGUI\{bin,obj}\` because the repo lives on Google Drive, whose sync client locks `obj\` mid-build. Look there for the built exe. `yt-dlp.exe` is expected next to the built exe (`AppDomain.CurrentDomain.BaseDirectory`) unless the user picks another path.

## Architecture

- `Program.cs` sets the colour mode from settings (must happen before any window exists), then starts `frmMain`, the only form. `frmMain.Designer.cs` is designer-generated, so keep hand edits consistent with it.
- `frmMain.cs` validates input (http(s) URL, yt-dlp exists, save folder creatable), then runs `yt-dlp` directly (no `cmd.exe`) with `ProcessStartInfo.ArgumentList`, so paths and URLs are never string-concatenated into a command line. Output is streamed asynchronously into `tbx_Log`, and Cancel kills the process tree.
- Version is `1.0.$(BuildNumber)`, computed in the csproj as days since 2000-01-01 on the build date, so it changes daily with no manual bump. `frmAbout` (opened by `btn_About`) reads it from the assembly version and derives the build date from it.
- User-visible changes should get an entry under `[Unreleased]` in `CHANGELOG.md`.
- `Helpers/HelperToolLocator` finds `yt-dlp.exe`/`ffmpeg.exe` (saved path, app folder, then `PATH`).
- Settings live in `Helpers/AppSettings` (JSON at `%LOCALAPPDATA%\YtDlpGUI\settings.json`, accessed via `AppSettings.Current`). `SaveSettings()` in `frmMain` writes them on download start and on close. The legacy `Properties/Settings.settings` + `App.config` are kept only so `AppSettings` can import old values once, when the JSON file doesn't exist yet. Don't add new settings there. Language changes apply live, and dark mode applies on next launch.

### Localisation (non-obvious)

UI text is not set in the designer. `HelperLocalisationResourceManager.ApplyLabels` (used by both `frmMain` and `frmAbout`) walks every control recursively and sets `control.Text` to the resource string whose **key equals `control.Name`**, looked up via `Helpers/HelperLocalisationResourceManager`.

- To add or rename a labelled control, add a matching key in both `Resources.resx` (neutral, en-GB) and `Resources.hu.resx` (Hungarian).
- Message-box strings are accessed as typed properties (`YtDlpGUI.Resources.msgb_*`) from `Resources.Designer.cs`.
- `Resources.Designer.cs` is generated from `Resources.Designer.tt` (T4, via Visual Studio) rather than by the default resx generator (the csproj clears the resx `Generator`). Regenerate it from the .tt after adding keys. `ResXManager.config.xml` configures the ResXManager VS extension.
- Language is `hu` or `en` (default `en`). Lookups pass the culture explicitly, and `ApplyLanguage` sets `Resources.Culture` for the typed `msgb_*` properties.
- Controls without a resource key keep their existing text.
