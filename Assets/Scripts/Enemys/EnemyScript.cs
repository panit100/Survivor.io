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

    void Start()
    {
        SetupComponent();
    }
    void SetupComponent()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        enemyMoveSpeedCurrent = enemyMoveSpeedDefault;
    }

    void FixedUpdate()
    {
        MoveToPlayer();
    }

    void MoveToPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, enemyMoveSpeedCurrent);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Instantiate(expItem,transform.position,Quaternion.identity);
            Destroy(this.gameObject);
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