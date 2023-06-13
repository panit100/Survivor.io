using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float enemyMoveSpeedDefault;
    float enemyMoveSpeedCurrent;
    public float enemyDamage;
    Transform playerTransform;

    void Start()
    {
        SetupComponent();
    }
    void SetupComponent()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        enemyMoveSpeedCurrent = enemyMoveSpeedDefault;
    }


    void Update()
    {
        MoveToPlayer();
    }
    void MoveToPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, enemyMoveSpeedCurrent);
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