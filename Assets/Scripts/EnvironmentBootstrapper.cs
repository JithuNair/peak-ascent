using UnityEngine;

public static class EnvironmentBootstrapper
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static void CreateGenerator()
    {
        if (Object.FindObjectOfType<EnvironmentGenerator>() == null)
        {
            var go = new GameObject("EnvironmentGenerator");
            go.AddComponent<EnvironmentGenerator>();
            Debug.Log("Spawned EnvironmentGenerator at runtime");
        }
    }
}
