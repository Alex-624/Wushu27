using UnityEngine;
using System.Collections;

public class MultiPrefabSpawner : MonoBehaviour
{
    [System.Serializable]
    public class SpawnEntry
    {
        [Tooltip("Time (in seconds from Play) when this prefab should be spawned")]
        public float timeFromStart = 1f;

        [Tooltip("Position where the prefab will be spawned")]
        public Vector3 position = Vector3.zero;

        [Tooltip("Rotation for the spawned prefab (optional)")]
        public Vector3 rotationEuler = Vector3.zero;
    }

    [Header("Prefab to Spawn")]
    public GameObject prefabToSpawn;

    [Header("Spawn Schedule")]
    public SpawnEntry[] spawns;

    private void Start()
    {
        if (prefabToSpawn == null)
        {
            Debug.LogWarning("MultiPrefabSpawner: No prefab assigned!");
            return;
        }

        if (spawns == null || spawns.Length == 0)
        {
            Debug.LogWarning("MultiPrefabSpawner: No spawn events configured!");
            return;
        }

        foreach (var entry in spawns)
        {
            StartCoroutine(SpawnAfterDelay(entry));
        }
    }

    private IEnumerator SpawnAfterDelay(SpawnEntry entry)
    {
        if (entry.timeFromStart > 0f)
            yield return new WaitForSeconds(entry.timeFromStart);

        Quaternion rotation = Quaternion.Euler(entry.rotationEuler);
        Instantiate(prefabToSpawn, entry.position, rotation);
    }
}
