using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Environment/Tile Data")]
public class TileData : ScriptableObject
{
    public GameObject prefab;
    public TerrainType terrainType;
    public List<TileData> allowedNeighbors;
}

public enum TerrainType
{
    Grass,
    Rock,
    Forest,
    Mountain
}
