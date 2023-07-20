using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TA
{
    public class BombItemScript : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other) 
        {
            if(other.CompareTag("Player"))
            {
                FindObjectOfType<EnemySpawner>().GetComponent<EnemySpawner>().DestroyAllEnemy();
                
                Destroy(gameObject);
            }
        }
    }

}
