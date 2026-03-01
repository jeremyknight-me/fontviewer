# Font Viewer
Font Viewer is a small Windows WPF application (C#) created as a learning project for WPF and Blazor integration. It helps inspect and preview fonts on Windows.

## Versions
- **V2** — WPF + BlazorWebView: allows opening and previewing any font file (supports local files via the embedded Blazor view and WebView2). This is the active implementation on the repository's `main` branch.
- **V1** — WPF-only: simple viewer for fonts that are already installed on the Windows system. This older version is archived on the `v1-wpf-only` branch.

## Requirements
- Windows 10/11 (desktop environment)
- .NET SDK (`net9.0-windows`)
- Microsoft Edge WebView2 runtime (required for V2 / BlazorWebView functionality)
- Visual Studio 2022/2023 or the `dotnet` CLI for building and running

If you don't have WebView2 installed, download and install the Evergreen WebView2 runtime from Microsoft.

## Quick Start

### CLI 

Open a command prompt in the repository root and run:

```bash
dotnet build
dotnet run --project FontViewer
```

### Visual Studio

Open `WindowsFontViewer.slnx` in Visual Studio and run the `FontViewer` project.

## Contributing
- Open an issue for bugs or feature requests.
- Fork the repository and create a feature branch for pull requests (`feature/your-feature-name`).
- Keep C# code formatted with consistent style (follow project conventions).
- Add tests (if any) and ensure changes build on CI/local machine before submitting a PR.
