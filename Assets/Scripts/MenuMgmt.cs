using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMgmt : MonoBehaviour
{
   public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Debug.Log("Game is quitting");
        Application.Quit();

    }
}
