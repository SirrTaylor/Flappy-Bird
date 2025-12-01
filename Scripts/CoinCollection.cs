using UnityEngine;

public class CoinCollection : MonoBehaviour
{

    public GameManager scoreManager; 

     void Start()
    {
      
        GameObject gameManagerObject = GameObject.Find("GameManager");

        if (gameManagerObject != null)
        {
           
            scoreManager = gameManagerObject.GetComponent<GameManager>();
        }
        
        
        if (scoreManager == null)
        {
            Debug.LogError("Coin.cs Error: ScoreManager not found! Make sure there is an object in the scene named 'GameManager' that has a 'ScoreManager' script attached.");
        }
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
         if (other.CompareTag("Player"))
        {
            // --- Collection Logic Goes Here ---

            Debug.Log("Coin collected!");

            if (scoreManager!= null)
            {
                scoreManager.HitCoin();
            }

            Destroy(gameObject);
        }
        
    }
}
