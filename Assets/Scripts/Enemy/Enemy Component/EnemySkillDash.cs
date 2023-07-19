using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TA
{
    public class EnemySkillDash : MonoBehaviour
    {
        public float skillCooldownTime = 5f;
        public float dashForce;
        
        Rigidbody2D rigidbody2D;
        EnemyMove enemyMove;

        void Start()
        {
            SetComponent();
            InvokeRepeating("EnemyActiveSkill", skillCooldownTime, skillCooldownTime);
        }
        void SetComponent()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
            enemyMove = GetComponent<EnemyMove>();
        }
        void EnemyActiveSkill()
        {
            EnemyDash();
        }

        void EnemyDash()
        {
            Vector2 dashDirection = enemyMove.playerTransform.position - transform.position;
            rigidbody2D.AddForce(dashDirection * dashForce);
        }
    }
}
