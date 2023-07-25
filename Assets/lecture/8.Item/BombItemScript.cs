using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TA
{
    public class BombItemScript : MonoBehaviour
    {
        EnemySpawner enemySpawner;

        void Start() 
        {
            enemySpawner = FindObjectOfType<EnemySpawner>().GetComponent<EnemySpawner>();    
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

}
