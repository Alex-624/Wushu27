using UnityEngine;
using System.Collections;


public class Spawn : MonoBehaviour
{
    int steps = 4;
    float startScale; // 8 steps, x2/step
    float currentScale;

    [Tooltip("Final scale of the spawned object")]
    public Vector3 finalScale = new Vector3(1f, 0.25f, 2f);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnCoroutine(steps));
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator SpawnCoroutine(int steps)
    {
        startScale = 1 / Mathf.Pow(2, steps);
        currentScale = startScale;
        for (int counter = 0; counter < steps; counter++)
        {
            transform.root.localScale = currentScale * finalScale;
            currentScale *= 2;
            yield return new WaitForSeconds(0.05f);

        }
        transform.root.localScale = currentScale * finalScale;

    }
}
