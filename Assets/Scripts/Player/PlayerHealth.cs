using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("HP")]
    public float maxHealth = 10f;
    public float currentHealth = 0f;

    [Header("GameOver")]
    public GameObject canvasGameOver;
    bool isPlayerGameOver = false;

    [Header("UI")]
    public Image healthBarImage;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        Time.timeScale = 1;

    }

    void Update() 
    {
        UpdateHP();
    }

    void FixedUpdate()
    {
        CheckHP();
    }

    public void Heal(float amount)
    {
        currentHealth += amount;

        if(currentHealth > maxHealth)
            currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }

    void CheckHP()
    {
        if(isPlayerGameOver == false && currentHealth <= 0)
        {
            GameOver();
        }
    }

    void UpdateHP()
    {
        if(currentHealth > 0)
            healthBarImage.fillAmount = currentHealth / maxHealth;
        else
            healthBarImage.fillAmount = 0;
    }

    void GameOver()
    {
        isPlayerGameOver = true;
        Instantiate(canvasGameOver);
        Time.timeScale = 0;
    }
}
