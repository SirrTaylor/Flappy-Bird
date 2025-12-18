using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    // --- Tunable Variables in the Inspector ---
    [Header("Timing and Randomness")]
    [Tooltip("Time delay between each pipe spawn.")]
    [SerializeField] public float maxTime = 1.5f;
    [Tooltip("Maximum vertical offset from the spawner's Y position.")]
    [SerializeField] public float heightRange = 10f;

    [Header("Pipe Prefabs and Gap")]
    [Tooltip("The vertical distance (gap size) between the top and bottom pipes.")]
    [SerializeField] public float pipeGapDistance = 5f;
    [Tooltip("Prefab for the TOP pipe column.")]
    [SerializeField] public GameObject topPipePrefab;
    [Tooltip("Prefab for the BOTTOM pipe column.")]
    [SerializeField] public GameObject bottomPipePrefab;
    
    
    // --- NEW VARIABLE ---
    [Header("Scoring")]
    [Tooltip("Prefab for the scoring trigger box placed in the gap.")]
    [SerializeField] public GameObject scoringTriggerPrefab;



    // --- Private Fields ---
    private float _timer;

    void Start()
    {
        // Spawn the first set of pipes immediately
        SpawnPipes();
    }

    public void Update()
    {
        if (_timer > maxTime)
        {
            SpawnPipes();
            _timer = 0;
        }

        _timer += Time.deltaTime;
    }
    public void SpawnPipes()
    {
        // 1. Determine the random Y offset for the *center* of the gap
        float randomYOffset = Random.Range(-heightRange, heightRange);

        Vector3 spawnerPosition = transform.position;

        // 2. Calculate the positions for the bottom, top, AND the trigger (center)
        
        // **Center Position (Trigger Position):**
        Vector3 triggerSpawnPos = new Vector3(spawnerPosition.x, spawnerPosition.y + randomYOffset, 0);

        // Bottom and Top Pipe Positions (based on the center)
        float bottomY = triggerSpawnPos.y - (pipeGapDistance / 2f);
        Vector3 bottomSpawnPos = new Vector3(spawnerPosition.x, bottomY, 0);

        float topY = triggerSpawnPos.y + (pipeGapDistance / 2f);
        Vector3 topSpawnPos = new Vector3(spawnerPosition.x, topY, 0);


        // 3. Instantiate the pipes and the scoring trigger
        GameObject bottomPipe = Instantiate(bottomPipePrefab, bottomSpawnPos, Quaternion.identity);
        GameObject topPipe = Instantiate(topPipePrefab, topSpawnPos, Quaternion.identity);

        // --- NEW INSTANTIATION ---
        GameObject scoringTrigger = Instantiate(scoringTriggerPrefab, triggerSpawnPos, Quaternion.identity);


        // 4. Clean up
        Destroy(bottomPipe, 10f);
        Destroy(topPipe, 10f);
        Destroy(scoringTrigger, 10f); // Destroy the trigger along with the pipes
    }

}