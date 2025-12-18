using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMgmt : MonoBehaviour
{
    public GameObject settingsView, menuView;
   public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Debug.Log("Game is quitting");
        Application.Quit();

    }

    public void Settings()
    {
        menuView.SetActive(false);
        settingsView.SetActive(true);
    }

    public void Back()
    {
        menuView.SetActive(true);
        settingsView.SetActive(false);
    }
}
