using UnityEngine;
using System.Collections;

public class Despawner : MonoBehaviour
{
    void Start()
    {
        // Start the despawn coroutine
        StartCoroutine(ShrinkAndDestroy());
    }

    private IEnumerator ShrinkAndDestroy()
    {
        Vector3 originalScale = transform.localScale;
        float shrinkDuration = 0.2f; // Duration of the shrinking effect
        float elapsedTime = 0f;

        // wait 3 sec
        yield return new WaitForSeconds(3f);

        while (elapsedTime < shrinkDuration)
        {
            float scale = Mathf.Lerp(1f, 0f, elapsedTime / shrinkDuration);
            transform.localScale = originalScale * scale;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the object is completely shrunk
        transform.localScale = Vector3.zero;

        // Destroy the object after shrinking
        Destroy(gameObject);
    }
}
