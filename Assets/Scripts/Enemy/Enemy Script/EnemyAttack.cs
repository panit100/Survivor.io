using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TA
{
    public class EnemyAttack : MonoBehaviour
    {
        public float enemyDamage;

        void OnTriggerEnter2D(Collider2D other) 
        {
            if(other.tag == "Player")
            {
                other.GetComponent<TA.PlayerHealth>().TakeDamage(enemyDamage); // สอนพิม
            }
        }
    }
}
