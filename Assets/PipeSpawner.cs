using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;   // prefab that contains both TopPipe & BottomPipe
    public float spawnRate = 2f;    // how often pipes spawn
    public float gapSize = 2.5f;    // vertical gap between top and bottom pipe
    public float minY = -1f;        // minimum Y offset for pipes
    public float maxY = 2f;         // maximum Y offset for pipes
    public float pipeSpeed = 2f;    // movement speed of pipes

    void Start()
    {
        InvokeRepeating("SpawnPipe", 1f, spawnRate);
    }

    void SpawnPipe()
    {
        // Pick a random vertical offset
        float y = Random.Range(minY, maxY);

        // Spawn the pipe pair
        GameObject pipe = Instantiate(pipePrefab, new Vector3(5, y, 0), Quaternion.identity);

        // Add movement script
        PipeMovement move = pipe.AddComponent<PipeMovement>();
        move.speed = pipeSpeed;

        // Destroy after 10s so they don’t pile up
        Destroy(pipe, 10f);
    }
}