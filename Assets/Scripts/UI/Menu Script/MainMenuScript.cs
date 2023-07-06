using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject exitWindow;
    
    void Start()
    {
        SetupUI();
    }
    void SetupUI()
    {
        mainMenu.SetActive(true);
        exitWindow.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}