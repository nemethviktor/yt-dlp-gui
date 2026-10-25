# Changelog

All notable changes to this project are documented here. The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/).

Versions are `1.0.<build>`, where the build number is the number of days since 1 January 2000 on the day of the build.

## [Unreleased]

## [1.0.9794] - 2026-10-25

First public release.

### Added
- Download audio as MP3, or video with a choice of format (mp4, mkv, webm) and maximum quality (Best, 2160p down to 360p).
- Live yt-dlp output in a log box, and a Cancel button that stops a running download.
- Input validation (http(s) URL, yt-dlp exists, save folder is created if missing) and a warning when `ffmpeg` can't be found.
- English and Hungarian UI (English by default). Language changes apply immediately.
- Dark mode (applies after a restart).
- Local settings store at `%LOCALAPPDATA%\YtDlpGUI\settings.json` (yt-dlp path, save folder, language, dark mode, audio/video mode, video format and quality, window position and size). Values from the old .NET user settings are imported once.
- About dialog with version, build number and date, license, project links and the unofficial-project disclaimer.
- Build number versioning: `1.0.<days since 2000-01-01>`, computed automatically at build time.
- Release builds publish a single self-contained `YtDlpGUI.exe` (no .NET runtime or extra files needed). A plain Release build also publishes.
- MIT license, and README with screenshot, disclaimer and an explanation of the exe size.

### Changed
- The window title is now "yt-dlp GUI".
- The target framework is `net10.0-windows`, which drops an unused 27 MB Windows SDK projection DLL from the output.
- Build output goes to `%LOCALAPPDATA%\build\YtDlpGUI\` instead of the Google Drive synced folder.

### Fixed
- The command line was built by string concatenation and run through `cmd.exe`, so paths with spaces broke it and a crafted URL could inject commands. yt-dlp is now started directly with separate arguments.
- The window froze during a download. Downloads now run in the background.
- The saved yt-dlp path was ignored on startup.
- Settings were only saved by accident (when the save folder text changed).
- Controls without a resource key had their text blanked by the localisation code.

[Unreleased]: https://github.com/nemethviktor/yt-dlp-gui/compare/v1.0.9794...HEAD
[1.0.9794]: https://github.com/nemethviktor/yt-dlp-gui/releases/tag/v1.0.9794
