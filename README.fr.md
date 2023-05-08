# ClearCache

:fr: [Lire en français](README.fr.md)

:uk: [Read in english](README.md)

## Description

Ce script vous permet de supprimer les fichiers de cache de votre ordinateur (Windows & FiveM).

## Installation

1. Allez sur la [dernière release](https://github.com/SUP2Ak/ClearCache/releases/)
2. Téléchargez la dernière version dans la section *Assets* (fichier `.zip`)
3. Extrayez le fichier `.zip`

## Usage

1. Lancez le fichier `ClearCache.exe`
2. Cliquez sur le bouton `Clear`
3. Attendez la fin du processus

- Si votre dossier FiveM n'est pas situé dans `C:\Users\%USERNAME%\AppData\Local\FiveM`, vous devez créer un fichier situé dans le même dossier que le fichier `ClearCache.exe` nommé `config.json` avec le contenu suivant: __(remplacez `C:\\Users\\%USERNAME%\\AppData\\Local\\FiveM` par le chemin de votre dossier FiveM et utilisez ``\\`` au lieu de `\`)__

```json
{
    "FiveMFolder": "C:\\Users\\%USERNAME%\\AppData\\Local\\FiveM"
}
```

## License

Ce projet est sous [GNU General Public License v3.0](LICENSE).