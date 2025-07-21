using UnityEngine;


public static class EnvironmentBootstrapper
{
    const float PlayerYOffset = 2f;

    static GameObject CreateDefaultPlayer()
    {
        GameObject player = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        Object.Destroy(player.GetComponent<Collider>()); // remove the capsule collider
        player.AddComponent<CharacterController>();
        player.AddComponent<PlayerController>();
        return player;
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static void Setup()
    {
        // Ensure an EnvironmentGenerator exists
        EnvironmentGenerator generator = Object.FindObjectOfType<EnvironmentGenerator>();
        if (generator == null)
        {
            var go = new GameObject("EnvironmentGenerator");
            generator = go.AddComponent<EnvironmentGenerator>();
            Debug.Log("Spawned EnvironmentGenerator at runtime");
        }

        // Spawn the player if one isn't in the scene
        if (Object.FindObjectOfType<PlayerController>() == null)
        {
            GameObject prefab = Resources.Load<GameObject>("Player");
            GameObject player;
            if (prefab != null)
            {
                player = Object.Instantiate(prefab);
                Debug.Log("Spawned Player prefab");
            }
            else
            {
                Debug.LogWarning("Player prefab not found in Resources. Creating default player.");
                player = CreateDefaultPlayer();
            }

            Vector3 pos = new Vector3(generator.gridSize.x / 2f, PlayerYOffset, generator.gridSize.y / 2f);
            player.transform.position = pos;
            player.name = "Player";

            // Attach main camera as a child so it follows the player
            if (Camera.main != null)
            {
                Camera.main.transform.SetParent(player.transform);
                Camera.main.transform.localPosition = new Vector3(0f, 1.6f, -3f);
                Camera.main.transform.localRotation = Quaternion.Euler(10f, 0f, 0f);
                var controller = player.GetComponent<PlayerController>();
                if (controller != null && controller.cameraTransform == null)
                {
                    controller.cameraTransform = Camera.main.transform;
                }
            }
        }
    }
}
