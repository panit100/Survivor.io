using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombItemScript : MonoBehaviour
{
    // EnemySpawner enemySpawner;
    EnemySpawnerPooling enemySpawner;

    void Start() 
    {
        // enemySpawner = FindObjectOfType<EnemySpawner>().GetComponent<EnemySpawner>();   
        enemySpawner = FindObjectOfType<EnemySpawnerPooling>().GetComponent<EnemySpawnerPooling>();    
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            enemySpawner.DestroyAllEnemy();

            Destroy(this.gameObject);
        }
    }
}
