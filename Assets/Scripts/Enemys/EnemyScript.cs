using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float enemyMoveSpeedDefault;
    float enemyMoveSpeedCurrent;
    public float enemyDamage;

    [HideInInspector]
    public Transform playerTransform;
    [SerializeField] GameObject expItem;
    [SerializeField] float health = 10;

    float currentHealth = 10;

    [SerializeField] bool moveToPlayer = true;

    public EnemySpawnerPooling enemySpawner;

    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        enemyMoveSpeedCurrent = enemyMoveSpeedDefault;

        SetupComponent();
    }
    public void SetupComponent()
    {
        currentHealth = health;
    }

    void FixedUpdate()
    {
        if(moveToPlayer)
            MoveToPlayer();
    }

    void MoveToPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, enemyMoveSpeedCurrent);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            Instantiate(expItem,transform.position,Quaternion.identity);
            enemySpawner.enemyContainer.Remove(this.gameObject);
            gameObject.SetActive(false);
            // Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            other.GetComponent<PlayerScript>().TakeDamage(enemyDamage);
            StopMove();
        }
    }
    void OnTriggerExit2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            ContinueMove();
        }
    }

    void StopMove()
    {
        enemyMoveSpeedCurrent = 0;
    }
    void ContinueMove()
    {
        enemyMoveSpeedCurrent = enemyMoveSpeedDefault;
    }
}