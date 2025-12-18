using UnityEngine;

public class ScoringTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 1. Check for collision with the Player
        if (collision.gameObject.CompareTag("Player"))
        {
            
            if (GameManager.Instance != null)
            {
                
                GameManager.Instance.HitPoint();
            }else
            {
                Debug.LogError("ScoringTrigger: GameManager Instance not found!");
            }
            
            
            Destroy(gameObject); 
            
        }
    }
}