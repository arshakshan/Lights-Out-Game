using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRedPacks : MonoBehaviour

{
    public Transform[] spawnPoints; // Array of spawn points
    public GameObject objectToSpawn; // The object prefab to spawn

    void Start()
    {
        // Start spawning objects at random intervals
        InvokeRepeating("SpawnObjectAtRandomTime", 0f, Random.Range(2f, 5f)); // Adjust the range as needed
    }

    void SpawnObjectAtRandomTime()
    {
        // Choose a random spawn point
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[spawnPointIndex];

        // Instantiate the object at the chosen spawn point
        Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
    }

}
