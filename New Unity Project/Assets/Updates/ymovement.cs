using System.Collections;
using UnityEngine;

public class YMovement : MonoBehaviour
{
    public float speed = 5f; // Adjust the speed as needed
    public Transform[] spawnPoints; // Array of spawn points

    private int currentSpawnPointIndex = 0;

    void Start()
    {
        // Set the initial position to a random spawn point
        if (spawnPoints.Length > 0)
        {
            currentSpawnPointIndex = Random.Range(0, spawnPoints.Length);
            transform.position = spawnPoints[currentSpawnPointIndex].position;
        }

        // Start spawning objects at random intervals
        InvokeRepeating("SpawnAtRandomTime", 0f, Random.Range(2f, 5f)); // Adjust the range as needed
    }

    void Update()
    {
        // Move the object along the x-axis continuously
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    void SpawnAtRandomTime()
    {
        // Move to the next spawn point
        currentSpawnPointIndex = Random.Range(0, spawnPoints.Length);
        transform.position = spawnPoints[currentSpawnPointIndex].position;
    }
}
