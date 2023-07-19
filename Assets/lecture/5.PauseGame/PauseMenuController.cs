using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TA
{

public class PauseMenuController : MonoBehaviour
{
    public GameObject pauseGamePrefab;        // หน้า pause game: พิมค้นหา "Pause Game UI" ในช่องค้นหาใน hierarchy

    Transform pauseGameUI;
    PlayerHealth PlayerHealth;

    void Start()
    {
        SetupComponent();
        SetupUI();
    }
    void SetupComponent()
    {
        PlayerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }
    void SetupUI()
    {
        pauseGameUI = Instantiate(pauseGamePrefab, GameObject.FindGameObjectWithTag("Canvas").transform).transform;

        pauseGameUI.Find("Button Resume Game").GetComponent<Button>().onClick.AddListener(ResumeGame);
        pauseGameUI.Find("Button Restart Game").GetComponent<Button>().onClick.AddListener(RestartGame);
        pauseGameUI.Find("Button Quit To Menu").GetComponent<Button>().onClick.AddListener(QuitToMenu);
        pauseGameUI.Find("Button Exit Game").GetComponent<Button>().onClick.AddListener(ExitGame);

        pauseGameUI.gameObject.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            CheckPauseGame();
        }
    }
    void CheckPauseGame()
    {
        if(Time.timeScale == 1 && PlayerHealth.currentHealth > 0)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    void PauseGame()
    {
        pauseGameUI.gameObject.SetActive(true);
        Time.timeScale = 0;                     // Time ใช้จัดการเวลาใน Unity, timeScale ใช้กำหนดเวลาเกม 1 = เวลาปกติ, 0 = หยุดเวลา, 2 = เร็วขึ้นสองเท่า
    }
    void ResumeGame()
    {
        pauseGameUI.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void QuitToMenu()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;
    }
    void ExitGame()
    {
        Application.Quit();
    }
}

}