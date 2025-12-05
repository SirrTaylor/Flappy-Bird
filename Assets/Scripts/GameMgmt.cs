using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance;
    
    [SerializeField] public GameObject _gameoverScreen;
    
    private int currentScore = 0;
    private int coinsCollected = 0;


    public TextMeshProUGUI scoreText; 
    public TextMeshProUGUI coinText;
    
    
    void Awake()
    {
        Instance = this; 
        UpdateUI(); 

        if(Instance==null)
        {
            Instance =this;
        }

        Time.timeScale=1f;
    }
       private void UpdateUI()
    {
        scoreText.text = "Score: " + currentScore.ToString();
        coinText.text = "Coins: " + coinsCollected.ToString();
    }

     public void GameOver()
    {
        _gameoverScreen.SetActive(true);

        Time.timeScale=0f;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
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

    
 

    
}