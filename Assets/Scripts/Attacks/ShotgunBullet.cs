using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TA
{
    public class ShotgunBullet : MonoBehaviour
    {
        [SerializeField] private float bulletDamage = 8f;
        [SerializeField] private float bulletSpeed = .5f;
        [SerializeField] private float bulletPushForce = 100f;
        [SerializeField] private float bulletSelfDestroyTime = 0.5f;

        public void SetupBulletProperty(float damage)
        {
            bulletDamage = damage;
            Destroy(this.gameObject, bulletSelfDestroyTime);
        }

        private void FixedUpdate() 
        {
            BulletMove();
        }
        private void BulletMove()
        {
            transform.Translate(Vector3.up * Time.deltaTime * bulletSpeed);
        }

        private void OnTriggerEnter2D(Collider2D enemy) 
        {
            if(enemy.tag == "Enemy")
            {
                DamageEnemy(enemy.gameObject);
                Destroy(this.gameObject);
            }
        }
        private void DamageEnemy(GameObject enemy)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(bulletDamage);
        }
    }
}
