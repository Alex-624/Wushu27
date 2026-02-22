using UnityEngine;

public class BreakOnCollision : MonoBehaviour
{
    [Header("Broken version of this object")]
    [SerializeField] private GameObject brokenPrefab;

    [Header("Optional: only break once")]
    private bool hasBroken = false;

    // Use OnCollisionEnter for normal 3D collisions
    /*
    private void OnCollisionEnter(Collision collision)
    {
        Break();
    }
    */


    // Use this instead if using triggers:
    private void OnTriggerEnter(Collider other)
    {
        Break();
    }


    private void Break()
    {
        if (hasBroken) return;
        hasBroken = true;

        if (brokenPrefab == null)
        {
            Debug.LogWarning($"No brokenPrefab assigned on {name}!");
            return;
        }

        // Spawn broken version at the same position & rotation
        GameObject brokenInstance = Instantiate(
            brokenPrefab,
            transform.position,
            transform.rotation
        );

        // Keep the same parent in hierarchy
        brokenInstance.transform.SetParent(transform.parent);

        // Destroy the original object
        Destroy(gameObject);
    }
}
