using UnityEngine;

public class EnvironmentGenerator : MonoBehaviour
{
    public Vector2Int gridSize = new Vector2Int(10, 10);
    public TileData[] tiles;
    public float noiseScale = 0.3f;
    public int seed;
    public Transform parent;

    void Start()
    {
        LoadTiles();
        Generate();
        PositionCamera();
    }

    void LoadTiles()
    {
        if (tiles == null || tiles.Length == 0)
        {
            tiles = Resources.LoadAll<TileData>("");
            Debug.Log($"Loaded {tiles.Length} tile assets from Resources");
        }
    }

    void PositionCamera()
    {
        Camera cam = Camera.main;
        if (cam == null)
        {
            var camObj = new GameObject("Main Camera");
            cam = camObj.AddComponent<Camera>();
            cam.tag = "MainCamera";
        }
        float size = Mathf.Max(gridSize.x, gridSize.y);
        cam.transform.position = new Vector3(gridSize.x / 2f, size, -size);
        cam.transform.rotation = Quaternion.Euler(45f, 0f, 0f);
    }

    public void Generate()
    {
        if (parent == null)
        {
            parent = transform;
        }
        Random.InitState(seed);
        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                float noise = Mathf.PerlinNoise((x + seed) * noiseScale, (y + seed) * noiseScale);
                int index = Mathf.RoundToInt(noise * (tiles.Length - 1));
                index = Mathf.Clamp(index, 0, tiles.Length - 1);
                TileData data = tiles[index];
                Vector3 position = new Vector3(x, 0, y);
                if (data != null && data.prefab != null)
                {
                    GameObject obj = Instantiate(data.prefab, position, Quaternion.identity, parent);
                    Tile tileComponent = obj.GetComponent<Tile>();
                    if (tileComponent == null)
                    {
                        tileComponent = obj.AddComponent<Tile>();
                    }
                    tileComponent.data = data;
                    obj.name = $"{data.name}_{x}_{y}";
                }
            }
        }
    }
}
