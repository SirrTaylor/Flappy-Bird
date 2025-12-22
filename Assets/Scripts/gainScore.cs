using UnityEngine;

public class collectible : MonoBehaviour
{
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the colliding object has the "Player" tag
        if (collision.gameObject.CompareTag("Player"))
        {
            // 1. Call the Singleton's UpdateScore method
            if (PointCollection.instance != null)
            {
                PointCollection.instance.updateScore();
            }
            
            // 2. Destroy the collectible item after collection
            Destroy(gameObject);
        }
    
    }
}
