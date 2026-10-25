# YtDlpGUI

A small Windows Forms front-end for [yt-dlp](https://github.com/yt-dlp/yt-dlp). Paste a URL, pick a folder, choose audio-only (MP3) or video, and download. yt-dlp's output is shown live in a log box.

> **Disclaimer:** This project is an independent, unofficial tool. It is not endorsed by, affiliated with, or sponsored by yt-dlp or YouTube. "YouTube" is a trademark of Google LLC. You are responsible for making sure your downloads comply with the terms of service of the sites you use and with applicable copyright law.

## Requirements

- Windows, .NET 10 SDK (to build) or the .NET 10 Desktop Runtime (to run)
- `yt-dlp.exe`: put it next to `YtDlpGUI.exe`, put it on `PATH`, or browse to it in the app
- `ffmpeg.exe` (for **Audio Only** MP3 conversion and for merging separate video and audio streams): next to `yt-dlp.exe` or on `PATH`. The app warns if it can't find it.

## Build and run

```
dotnet build YtDlpGUI.csproj
dotnet run --project YtDlpGUI.csproj
```

Build output goes to `%LOCALAPPDATA%\build\YtDlpGUI\{bin,obj}\` (see `Directory.Build.props`) rather than the project folder, because the sources live on Google Drive.

## Usage

1. Check the yt-dlp location (auto-detected from the saved setting, the app folder, then `PATH`).
2. Enter an `http(s)` URL and the save folder (created if missing).
3. Choose **Audio Only** (MP3) or **Video Also**. For video, pick a container (mp4, mkv, webm) and a maximum quality (Best, or 2160p down to 360p) and press **OK**. Only the single video is downloaded, never the whole playlist.
4. **Cancel** stops a running download. When nothing is running it closes the app.

Settings are stored in `%LOCALAPPDATA%\YtDlpGUI\settings.json`: yt-dlp path, save folder, language, dark mode, audio/video mode, video format and quality, and window position and size. They are saved when you start a download and when the window closes. Language and dark mode are also saved as soon as you change them. Delete the file to reset everything. Language changes apply immediately. Dark mode applies after a restart.

Video quality is a cap: `Best` takes the highest available, otherwise the best stream at or below the chosen height. mp4 and webm prefer streams that already fit the container. If the video has no such streams at that quality, yt-dlp may fail to merge. Use mkv, which accepts anything.

## Localisation

The UI is available in English (default) and Hungarian. Control text is looked up in `Resources.resx` / `Resources.hu.resx` by the control's `Name`. See `CLAUDE.md` for the details.

## License

[MIT](LICENSE)
