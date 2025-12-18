using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using Unity.VisualScripting;

public class PointCollection : MonoBehaviour
{

    public static PointCollection instance;

    [SerializeField] public TextMeshProUGUI currScore;
    [SerializeField] public TextMeshProUGUI highScore;


    private int _score;

    public void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }

    public void Start()
    {
        currScore.text =_score.ToString();

        highScore.text = PlayerPrefs.GetInt("HighScore",0).ToString();

        updateHighSCore();
    }

    public void updateHighSCore()
    {
        if(_score > PlayerPrefs.GetInt("HighScore,0"))
        {
            PlayerPrefs.SetInt("HighScore", _score);
            highScore.text = _score.ToString();

            PlayerPrefs.Save();
        }
    }

    public void updateScore()
    {
        _score++;
        currScore.text = _score.ToString();
        updateHighSCore();
    }



}
