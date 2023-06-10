using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 10f;

    public float maxHealth = 10f;
    public float currentHealth = 0f;

    public int exp = 0;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        var diraction = new Vector2(horizontal,vertical).normalized;

        transform.Translate(diraction * speed * Time.deltaTime);

        // rigidbody2D.velocity = diraction * speed;
    }
}
