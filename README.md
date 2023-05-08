# ClearCache

:fr: [Lire en français](README.fr.md)

:uk: [Read in english](README.md)

## Description

This script allows you to clear cache files from your computer (Windows & FiveM).

## Installation

1. Go to [latest release](https://github.com/SUP2Ak/ClearCache/releases/)
2. Download the latest version in *Assets* section (`.zip` file)
3. Extract the `.zip` file

## Usage

1. Run `ClearCache.exe` file
2. Click on `Clear` button
3. Wait for the end of the process

- If your FiveM folder is not located in `C:\Users\%USERNAME%\AppData\Local\FiveM`, you need to create a files located in the same folder as `ClearCache.exe` file named `config.json` with the following content: __(replace `C:\\Users\\%USERNAME%\\AppData\\Local\\FiveM` by your FiveM folder path and use ``\\`` instead of `\`)__

```json
{
    "FiveMFolder": "C:\\Users\\%USERNAME%\\AppData\\Local\\FiveM"
}
```

## License

This project is under [GNU General Public License v3.0](LICENSE).