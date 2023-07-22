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
            // ใช้ tag ในการตรวจสอบว่าเป็น Player ที่เข้ามาใน Trigger
            // เรียกใช้ Function รับความเสียหายใน PlayerHealth
        }
    }
}