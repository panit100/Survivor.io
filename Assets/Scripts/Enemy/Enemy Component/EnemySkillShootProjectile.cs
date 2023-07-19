using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TA
{
    public class EnemySkillShootProjectile : MonoBehaviour
    {
        EnemyAttack enemyAttack;
        EnemyMove enemyMove;

        public Projectile projectilePrefab;
        
        public float fireRate = 5;

        float tempTime = 0;
        
        void Start() 
        {
            enemyAttack = GetComponent<EnemyAttack>();
            enemyMove = GetComponent<EnemyMove>();
        }

        void FixedUpdate()
        {
            tempTime += Time.deltaTime;

            if(tempTime >= fireRate)
            {
                Shoot();
                tempTime = 0;
            }
        }

        void Shoot()
        {
            Projectile projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            projectile.damage = enemyAttack.enemyDamage;
            projectile.direction = enemyMove.playerTransform.position - transform.position;
        }
    }
}

