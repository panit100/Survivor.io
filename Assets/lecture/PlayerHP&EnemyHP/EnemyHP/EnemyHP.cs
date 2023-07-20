using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TA
{
    public class EnemyHP : MonoBehaviour
    {
        public float health = 10;
        public float currentHealth;
        public EnemySpawner enemySpawner;
  
        void Start()
        {
            currentHealth = health;
        }
        public void TakeDamage(float damage)
        {
            currentHealth -= damage;

            if(currentHealth <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
