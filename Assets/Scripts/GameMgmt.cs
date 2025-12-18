using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance;
    
    [SerializeField] public GameObject gameoverScreen;
    
    public int currentScore,coinsCollected  = 0;
    public bool isGamePaused;
    public TextMeshProUGUI scoreText; 
    public TextMeshProUGUI coinText;
    public GameObject pauseScreen;
    
    
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

    
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameoverScreen.SetActive(false);
        Time.timeScale=1f;
    }

    public void Quit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
        Debug.Log("Game is quitting");
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
    public void PauseGame()
    {
       
       if( !isGamePaused) {
        Time.timeScale = 0f;
        isGamePaused = true;
        pauseScreen.SetActive(true);
       }
    }
    public void ResumeGame()
    {

        if (isGamePaused)
        {
            Time.timeScale = 1f;
            isGamePaused = false;
            pauseScreen.SetActive(false);
        }
    }
    
    public void GameOver()
    {
        gameoverScreen.SetActive(true);
        Time.timeScale=0f;
    }

    
 
    
}