# AnimalMatchingGame

Simple .NET MAUI memory matching game that pairs animal emoji tiles. Built for .NET 9 as a single-project MAUI app.

## Features
- 16 tiles (8 pairs) of animal emoji.
- Tap to reveal tiles and find matching pairs.
- Timer shows elapsed time.
- "Play Again?" button to reshuffle and restart.

## Prerequisites
- .NET 9 SDK installed.
- Visual Studio 2022/2026 or later with the **.NET MAUI** workload installed.
- Platform-specific tooling as required:
  - Android: Android SDK/NDK and emulator or device.
  - iOS/macOS: Xcode (on macOS).
  - Windows: Windows 10+ (with required SDK) for `net9.0-windows*` target.

## Running the app

Using Visual Studio
1. Open the solution `AnimalMatchingGame.sln`.
2. Set `AnimalMatchingGame` as the startup project.
3. Choose a run target (Android/iOS/MacCatalyst/Windows).
4. Start the app with __Debug > Start Debugging__ (F5) or __Debug > Start Without Debugging__ (Ctrl+F5).

Using dotnet CLI (build only)
- From the repository root:
  - `dotnet build` — builds the project for default targets.
- For platform-specific runs, use Visual Studio or platform tooling (recommended for MAUI).

Notes:
- Project TFM targets are: `net9.0-android`, `net9.0-ios`, `net9.0-maccatalyst`, and on Windows `net9.0-windows10.0.19041.0`. See `AnimalMatchingGame.csproj`.

## How to play
- Press the `Play Again?` button to start a game (reveals and shuffles tiles).
- Tap a tile to reveal its animal emoji. Tap another to try to find a match.
- Matched pairs become disabled and visually marked.
- When all 8 pairs are found, the tiles hide and `Play Again?` appears.

## Project layout (important files)
- `AnimalMatchingGame.csproj` — project file and target frameworks.
- `MainPage.xaml` — UI (tile buttons, timer, Play Again button).
- `MainPage.xaml.cs` — game logic (shuffling, matching, timer).
- `Resources/` — images, fonts, splash, app icon.

## Extending
- Add more pairs by updating `MainPage.xaml` buttons and the emoji list in `MainPage.xaml.cs`.
- Improve UX (flip animations, persistent high scores, difficulty levels).

## Contributing
- Fork, create a branch, and submit a PR.
- Keep changes consistent with MAUI single-project structure and .NET 9 targets.

## License
- No license file included. Add a `LICENSE` if you intend to publish.
