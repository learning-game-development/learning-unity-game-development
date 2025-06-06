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
