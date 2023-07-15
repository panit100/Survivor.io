using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TA
{
    public class EnemyHealth : MonoBehaviour
    {
        public float health = 10;
        public float currentHealth;
        public GameObject expItem;
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
                Instantiate(expItem,transform.position,Quaternion.identity);
                if(LayerMask.LayerToName(gameObject.layer) != "Boss")
                {
                    enemySpawner.enemyContainer.Remove(this.gameObject);
                }
                gameObject.SetActive(false);
            }
        }
    }
}
