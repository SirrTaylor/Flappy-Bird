using UnityEngine;

public class collectible : MonoBehaviour
{
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the colliding object has the "Player" tag
        if (collision.gameObject.CompareTag("Player"))
        {
            
            if (GameManager.Instance != null)
            {
                // 3. Call the public GameOver function on the GameManager.
                // This function handles pausing the game and showing the game over screen.
                GameManager.Instance.GameOver();
            }
            else
            {
                Debug.LogError("CollisionDeath: GameManager Instance not found! Cannot end game.");
            }
            // 2. Destroy the collectible item after collection
            Destroy(gameObject);
        }
    
    }
}
