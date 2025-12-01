using UnityEngine;
using TMPro; 

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance;
    
    
    private int currentScore = 0;
    private int coinsCollected = 0;


    public TextMeshProUGUI scoreText; 
    public TextMeshProUGUI coinText;
    
    
    void Awake()
    {
        Instance = this; 
        UpdateUI(); 
    }

    
    public void AddScore()
    {
        currentScore++;
        UpdateUI();
        
    }

    
    public void AddCoin()
    {
        coinsCollected++;
        UpdateUI();
    }

    public void HitPoint()
    {
        AddScore();
       
    }

     public void HitCoin()
    {
        AddCoin();
       
    }

    
    private void UpdateUI()
    {
        scoreText.text = "Score: " + currentScore.ToString();
        coinText.text = "Coins: " + coinsCollected.ToString();
    }

    
}