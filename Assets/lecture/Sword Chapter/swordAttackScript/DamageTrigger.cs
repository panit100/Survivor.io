using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TA
{
    public class DamageTrigger : MonoBehaviour
    {
        public float Damage = 10f;
      
        private void OnTriggerEnter2D(Collider2D enemy)
        {
            Debug.Log("hit");
            if(enemy.tag == "Enemy")
            {
                DoDamageToenemy(enemy);
            }
        }

        private void DoDamageToenemy(Collider2D enemy)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(Damage);
        }
    }
}
