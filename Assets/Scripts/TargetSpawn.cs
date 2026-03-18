using UnityEngine;
using System.Collections;

public class TargetSpawn : MonoBehaviour
{
    public Transform cornerA;
    public Transform cornerB;
    public Transform cornerC;
    public GameObject targetObject;

    private HUDScript hudScript;
    private bool isSpawning = false; // Prevents "Machine Gun" spawning

    void Start()
    {
        // Find this once at the start to save performance
        hudScript = Object.FindFirstObjectByType<HUDScript>();
    }

    void Update()
    {
        // Only start the spawn cycle if the timer is running and we aren't already waiting
        if (hudScript != null && hudScript.timerRunning && !isSpawning)
        {
            StartCoroutine(SpawnCycle());
        }
    }

    IEnumerator SpawnCycle()
    {
        isSpawning = true; // Lock the coroutine

        // 1. Calculate Position
        Vector3 sideAB = cornerB.position - cornerA.position;
        Vector3 sideAC = cornerC.position - cornerA.position;
        float a = Random.value;
        float b = Random.value;
        if (a + b > 1) { a = 1 - a; b = 1 - b; }

        Vector3 spawnPosition = cornerA.position + (sideAB * a) + (sideAC * b);
        spawnPosition.y = Random.Range(2.5f, 9f);

        // 2. Spawn the object
        GameObject newTarget = Instantiate(targetObject, spawnPosition, transform.rotation);

        // 3. Wait for 1.5 seconds while the object exists
        yield return new WaitForSeconds(1.5f);

        // 4. Destroy the object AFTER the wait
        if (newTarget != null)
        {
            Destroy(newTarget);
        }

        isSpawning = false; // Unlock so the next one can spawn
    }
}
