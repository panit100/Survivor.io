using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TA
{
    public class GameOverController : MonoBehaviour
    {
        public GameObject gameOverPrefab;
        Transform gameOverUI;

        bool isPlayerGameOver = false;
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
            gameOverUI = Instantiate(gameOverPrefab, GameObject.FindGameObjectWithTag("Canvas").transform).transform;

            gameOverUI.Find("Button Restart Game").GetComponent<Button>().onClick.AddListener(RestartGame);
            gameOverUI.Find("Button Quit To Menu").GetComponent<Button>().onClick.AddListener(QuitToMainMenu);
            gameOverUI.Find("Button Exit Game").GetComponent<Button>().onClick.AddListener(ExitGame);

            gameOverUI.gameObject.SetActive(false);
        }

        void FixedUpdate()
        {
            if(CheckIfPlayerDead())
            {
                GameOver();
            }
        }
        bool CheckIfPlayerDead()
        {
            if(isPlayerGameOver == false && PlayerHealth.currentHealth <= 0)
            {
                isPlayerGameOver = true;
            }
            
            return isPlayerGameOver; 
        }
        void GameOver()
        {
            isPlayerGameOver = true;
            gameOverUI.gameObject.SetActive(true);
            Time.timeScale = 0;
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        public void QuitToMainMenu()
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1;
        }
        public void ExitGame()
        {
            Application.Quit();
        }
    }
}