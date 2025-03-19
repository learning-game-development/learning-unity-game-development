# Game Assets

The assets folder will keep all game releated assets. For example music, sound, sprites, 3D models and other game graphics like sceenshots for marketing.

Create sub folders for each type of resource.

```folders
.
└── assets/
    ├── concept-art
    ├── music
    ├── sounds
    ├── sprites
    └── models
```

## Blender model files

Configure the repository to version only the Blender project file and not the backup files.

Rename `blender.gitattributes` and `blender.gitignore` to `.gitattributes` and `.gitignore` respectively, and place these files in the parent folder containing the [Blender](https://www.blender.org/) `.blend` files.

```folders
.
└── assets/
    └── models/
        ├── .gitattributes
        └── .gitignore
```

## Asesprite

Use the attributes file `aseprite.gitattributes` when using [Aseprite](https://www.aseprite.org/) to create your pixel art.
  
There are also git attribtes for commonly used graphics files in the `aseprite.gitattributes` file. Copy the contents of this attributes file and place them with all the other git attributes under the _assets_ folder.

## Tiled level editor

Configure the repository to version only the tiled-project, maps and tilesets and not the sesion files.

Rename the `tiled.gitignore` file to `.gitignore`, and place these files in the parent folder containing the [Tiled](https://www.mapeditor.org/) project.
