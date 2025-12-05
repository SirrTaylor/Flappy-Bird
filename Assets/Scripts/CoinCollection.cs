using UnityEngine;
using System.Collections;

public class CoinLifespan : MonoBehaviour
{
    
    public void StartLifespanTimer(float duration)
    {
        StartCoroutine(LifespanRoutine(duration));
    }

    private IEnumerator LifespanRoutine(float duration)
    {
     
        yield return new WaitForSeconds(duration);

  
        if (gameObject != null)
        {
            Destroy(gameObject);
        }
    }

    [System.Obsolete]
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
          
            if (PointCollection.instance != null)
            {
                PointCollection.instance.updateScore();
            }
 
            CoinSpawner spawner = FindObjectOfType<CoinSpawner>(); 
            if (spawner != null)
            {
                spawner.CoinCollected();
            }
            
           
            Destroy(gameObject);
        }
    }
}