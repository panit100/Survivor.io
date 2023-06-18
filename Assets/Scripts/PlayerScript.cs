using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 10f;

    public float maxHealth = 10f;
    public float currentHealth = 0f;
    public GameObject canvasGameOver;

    public int exp = 0;
    public int CurrentLevel = 1;

    

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        Move();
        CheckHP();
    }

    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        var diraction = new Vector2(horizontal,vertical).normalized;

        transform.Translate(diraction * speed * Time.deltaTime);

        // rigidbody2D.velocity = diraction * speed;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }

    bool isPlayerGameOver = false;
    void CheckHP()
    {
        if(isPlayerGameOver == false && currentHealth <= 0)
        {
            GameOver();
        }
    }
    void GameOver()
    {
        currentHealth = 0;
        isPlayerGameOver = true;
        Instantiate(canvasGameOver);
        Time.timeScale = 0;
    }
}
