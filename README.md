# peak-ascent

This project demonstrates a basic procedural environment generation system built in Unity.

## Overview

* `TileData` – ScriptableObject defining individual tile prefabs and metadata.
* `Tile` – MonoBehaviour holding a reference to its `TileData`.
* `EnvironmentGenerator` – spawns a grid of tiles using Perlin noise.

Run the generator in Play Mode to create a simple landscape of grass and rock tiles. A sample PlayMode test is included under `Tests/PlayMode` which verifies tile generation for a given seed.
