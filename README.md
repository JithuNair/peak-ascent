# peak-ascent

This project demonstrates a basic procedural environment generation system built in Unity.

## Overview

* `TileData` – ScriptableObject defining individual tile prefabs and metadata.
* `Tile` – MonoBehaviour holding a reference to its `TileData`.
* `EnvironmentGenerator` – spawns a grid of tiles using Perlin noise.
* `PlayerController` – simple third-person character with walking, sprinting and jumping. Stamina drain increases based on carried weight.
* `StaminaSystem` – tracks stamina values used by the player.
* `InventoryManager` – manages item slots and calculates total weight.
* `InventoryUI` – displays current slot usage and weight.
* `TileDataAutoSetup` – creates default prefabs and tile data on first play.

Run the generator in Play Mode to create a simple landscape of grass and rock tiles. A sample PlayMode test is included under `Tests/PlayMode` which verifies tile generation for a given seed. Unit tests for `StaminaSystem` and `InventoryManager` live in `Tests/Unit`.
The player can collect tools which are stored in a small backpack. Heavier packs cause faster stamina loss.