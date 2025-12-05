using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
   [SerializeField] public float maxTime =1.5f;
   [SerializeField] public float heightRange =0.45f;
   [SerializeField] public GameObject[] pipePrefabs;


    private float _timer;

    void Start()
    {
        SpawnPipe();
    }

    public void Update()
    {
      if (_timer > maxTime)
        {
            SpawnPipe();
            _timer=0;
        }

        _timer += Time.deltaTime;
    }

    public void SpawnPipe()
    {

        int randomIndex = Random.Range(0, pipePrefabs.Length);
        GameObject randomPipePrefab = pipePrefabs[randomIndex];

        float randomY = Random.Range(-heightRange, heightRange);

        Vector3 spawnPos = transform.position + new Vector3(0, randomY, 0);

        GameObject _pipe = Instantiate(randomPipePrefab, spawnPos, Quaternion.identity);

        Destroy(_pipe,10f);
    }
}
