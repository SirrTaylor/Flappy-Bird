using UnityEngine;
using System.Collections;
using System.Collections.Generic; 

public class CoinSpawner : MonoBehaviour
{
    [Header("Prefabs & Locations")]
    [Tooltip("Drag your Coin Prefab here.")]
    public GameObject coinPrefab;
    
    [Tooltip("Drag the Game Objects representing your spawn points here.")]
    public List<Transform> spawnPoints;

    [Header("Timing & Control")]
    [Tooltip("The time interval (in seconds) to wait before attempting to spawn a new coin.")]
    public float spawnInterval = 2.0f;

    [Tooltip("The time (in seconds) before an uncollected coin is automatically destroyed.")]
    public float coinLifespan = 5.0f; 

    
    private GameObject currentCoin = null;

    void Start()
    {
        if (coinPrefab == null || spawnPoints.Count == 0)
        {
            Debug.LogError("Coin Spawner requires a Coin Prefab and at least one Spawn Point assigned.");
            enabled = false;
            return;
        }

        
        StartCoroutine(SpawnControlRoutine());
    }

    private IEnumerator SpawnControlRoutine()
    {
        while (true)
        {
           
            yield return new WaitForSeconds(spawnInterval);

            
            if (currentCoin == null)
            {
                SpawnCoin();
            }
         
        }
    }

    
    private void SpawnCoin()
    {
      
        int randomIndex = Random.Range(0, spawnPoints.Count);
        Transform spawnLocation = spawnPoints[randomIndex];

       
        currentCoin = Instantiate(coinPrefab, spawnLocation.position, Quaternion.identity);

        
        CoinLifespan lifeController = currentCoin.GetComponent<CoinLifespan>();
        if (lifeController != null)
        {
            lifeController.StartLifespanTimer(coinLifespan);
        }
        else
        {
            Debug.LogWarning("Coin prefab is missing the CoinLifespan script. Coin will not despawn automatically.");
        }
    }
    
    
    public void CoinCollected()
    {
        currentCoin = null;
    }
}