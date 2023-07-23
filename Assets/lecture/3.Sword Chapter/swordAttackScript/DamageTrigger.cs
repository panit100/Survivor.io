using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TA
{
    public class DamageTrigger : MonoBehaviour
    {
        //public float Damage = 10f;ทำหลังระบบเลือด
      
        private void OnTriggerEnter2D(Collider2D enemy)
        {
            Debug.Log("hit");
            if(enemy.tag == "Enemy")
            {
                Destroy(enemy.gameObject);
                //DoDamageToEnemy(enemy);
            }
        }

        private void DoDamageToEnemy(Collider2D enemy)
        {
            Destroy(enemy.gameObject); // ก่อนระบบเลือด
            // enemy.GetComponent<EnemyHealth>().TakeDamage(Damage); ทำหลังระบบเลือด
        }
    }
}
