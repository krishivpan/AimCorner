using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UIElements;

public class TargetSpawn : MonoBehaviour
{

    public Transform cornerA;
    public Transform cornerB;
    public Transform cornerC;
    public GameObject targetObject;
    HUDScript HUDScript;

    void Update()
    {
        HUDScript = Object.FindFirstObjectByType<HUDScript>();
        if (HUDScript.timerRunning)
        {
            SpawnObject();

        }
    }

    void SpawnObject()
    {
        // Calculate weights: P = ax + by + cz
        Vector3 sideAB = cornerB.position - cornerA.position;
        Vector3 sideAC = cornerC.position - cornerA.position;

        float a = Random.value;
        float b = Random.value;
        float height = Random.Range(2.5f, 9f);

        if (a + b > 1)
        {
            a = 1 - a;
            b = 1 - b;
        }

        Vector3 spawnPosition = cornerA.position + (sideAB * a) + (sideAC * b);
        spawnPosition.y = height;

        Instantiate(targetObject, spawnPosition, transform.rotation);
        Invoke(nameof(targetObject), 3.0f);
        Destroy(targetObject);
    }

}
