using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public static class TileDataAutoSetup
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void EnsureTileData()
    {
#if UNITY_EDITOR
        const string prefabDir = "Assets/Prefabs";
        const string soRoot = "Assets/ScriptableObjects";
        const string soResourceDir = "Assets/ScriptableObjects/Resources";

        if (!AssetDatabase.IsValidFolder(prefabDir))
        {
            AssetDatabase.CreateFolder("Assets", "Prefabs");
            Debug.Log("Created folder " + prefabDir);
        }
        if (!AssetDatabase.IsValidFolder(soRoot))
        {
            AssetDatabase.CreateFolder("Assets", "ScriptableObjects");
            Debug.Log("Created folder " + soRoot);
        }
        if (!AssetDatabase.IsValidFolder(soResourceDir))
        {
            AssetDatabase.CreateFolder(soRoot, "Resources");
            Debug.Log("Created folder " + soResourceDir);
        }

        string materialPath = prefabDir + "/Tile_Grass.mat";
        Material mat = AssetDatabase.LoadAssetAtPath<Material>(materialPath);
        if (mat == null)
        {
            mat = new Material(Shader.Find("Standard"));
            mat.color = Color.green;
            AssetDatabase.CreateAsset(mat, materialPath);
            Debug.Log("Created material " + materialPath);
        }

        string prefabPath = prefabDir + "/Tile_Grass.prefab";
        GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
        if (prefab == null)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.GetComponent<Renderer>().sharedMaterial = mat;
            prefab = PrefabUtility.SaveAsPrefabAsset(cube, prefabPath);
            Object.DestroyImmediate(cube);
            Debug.Log("Created prefab " + prefabPath);
        }

        string assetPath = soResourceDir + "/GrassTile.asset";
        TileData tile = AssetDatabase.LoadAssetAtPath<TileData>(assetPath);
        if (tile == null)
        {
            tile = ScriptableObject.CreateInstance<TileData>();
            tile.prefab = prefab;
            tile.terrainType = TerrainType.Grass;
            tile.allowedNeighbors = new System.Collections.Generic.List<TileData>();
            AssetDatabase.CreateAsset(tile, assetPath);
            Debug.Log("Created TileData asset " + assetPath);
        }
        else if (tile.prefab == null)
        {
            tile.prefab = prefab;
            EditorUtility.SetDirty(tile);
            Debug.Log("Assigned prefab to existing TileData asset");
        }
        AssetDatabase.SaveAssets();
#endif
    }
}
