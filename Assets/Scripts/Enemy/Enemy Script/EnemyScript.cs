using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float enemyMoveSpeedDefault;
    float enemyMoveSpeedCurrent;
    public float enemyDamage;

    [HideInInspector] public Transform playerTransform;
    [SerializeField] GameObject expItem;
    [SerializeField] float health = 10;

    [SerializeField] float currentHealth = 10;

    [SerializeField] bool moveToPlayer = true;

    public EnemySpawner enemySpawner;
    SpriteRenderer Sprite;
    public bool flipModifier;

#region Start Setup

    void Start()
    {
        SetupComponent();
    }
    public void SetupComponent()
    {
        currentHealth = health;
        enemyMoveSpeedCurrent = enemyMoveSpeedDefault;

        Sprite = GetComponent<SpriteRenderer>();
        playerTransform = GameObject.FindWithTag("Player").transform;
    }
#endregion


#region Enemy Moving System

    void FixedUpdate()
    {
        if(moveToPlayer)
            MoveToPlayer();
            CheckEnemyFacing();
    }
    void MoveToPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, enemyMoveSpeedCurrent * Time.deltaTime);
    }
    void CheckEnemyFacing()
    {
        if(transform.position.x > playerTransform.position.x)
        {
            Sprite.flipX = true;
        }
        else if(transform.position.x < playerTransform.position.x)
        {
            Sprite.flipX = false;
        }
    }
#endregion


#region Enemy Health System

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            Instantiate(expItem,transform.position,Quaternion.identity);
            if(LayerMask.LayerToName(gameObject.layer) != "Boss")
            {
                enemySpawner.enemyContainer.Remove(this.gameObject);
            }
            gameObject.SetActive(false);
        }
    }
#endregion


#region Collider System

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            other.GetComponent<PlayerHealth>().TakeDamage(enemyDamage);
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
#endregion

}