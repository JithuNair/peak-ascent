using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;

public class EnvironmentGeneratorTests
{
    [UnityTest]
    public IEnumerator GeneratesExpectedTileCount()
    {
        var generatorGameObject = new GameObject("Generator");
        var generator = generatorGameObject.AddComponent<EnvironmentGenerator>();
        generator.gridSize = new Vector2Int(5, 5);
        generator.tiles = new TileData[1];
        generator.seed = 42;

        generator.Generate();

        yield return null;

        int tileCount = generatorGameObject.transform.childCount;
        Assert.AreEqual(generator.gridSize.x * generator.gridSize.y, tileCount);
    }
}
