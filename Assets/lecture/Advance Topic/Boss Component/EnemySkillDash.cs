using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TA
{
    public class EnemySkillDash : MonoBehaviour
    {
        public float skillCooldownTime = 5f;
        public float dashForce;
        
        Rigidbody2D rb;
        EnemyMove enemyMove;

        void Start()
        {
            SetComponent();
            InvokeRepeating("EnemyActiveSkill", skillCooldownTime, skillCooldownTime);
        }
        void SetComponent()
        {
            rb = GetComponent<Rigidbody2D>();
            enemyMove = GetComponent<EnemyMove>();
        }
        void EnemyActiveSkill()
        {
            EnemyDash();
        }

        void EnemyDash()
        {
            Vector2 dashDirection = enemyMove.playerTransform.position - transform.position;
            rb.AddForce(dashDirection * dashForce);
        }
    }
}
