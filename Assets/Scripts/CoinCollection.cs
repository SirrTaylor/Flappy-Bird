using UnityEngine;
using System.Collections;
using TMPro;


public class CoinLifespan : MonoBehaviour
{  

    

    public void StartLifespanTimer(float duration)
    {
        StartCoroutine(LifespanRoutine(duration));
        
    }

    private IEnumerator LifespanRoutine(float duration)
    {
     
        yield return new WaitForSeconds(duration);

  
        if (gameObject)
        {
            Destroy(gameObject);
        }
    }

    [System.Obsolete]
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.HitCoin();
            }
            else
            {
                Debug.LogError("CoinLifespan: GameManager Instance not found!");
            }
            
            Destroy(gameObject);
        }
    }
}