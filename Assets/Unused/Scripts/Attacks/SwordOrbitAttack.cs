using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TA
{
    public class SwordOrbitAttack : BaseAttack
    {
        [SerializeField] private float attackDamage = 10f;
        [SerializeField] private float attackCooldown = 1f;
        [SerializeField] private float attackAnimationSpeed = 1f;
        [SerializeField] private GameObject swordSpriteHolder;

        private Animator Animator;

        private void Start()
        {
            SetupComponent();
            SwingSword();
        }
        private void SetupComponent()
        {
            Animator = swordSpriteHolder.GetComponent<Animator>();
            swordSpriteHolder.SetActive(false);
            Animator.speed = attackAnimationSpeed;
        }

        private void SwingSword()
        {
            StopAllCoroutines();
            StartCoroutine(SwingSwordSequence());
        }
        private IEnumerator SwingSwordSequence()
        {
            swordSpriteHolder.SetActive(true);

            yield return new WaitForSeconds(attackAnimationSpeed);
            swordSpriteHolder.SetActive(false);

            yield return new WaitForSeconds(attackCooldown);
            SwingSword();
        }
        private void OnTriggerEnter2D(Collider2D enemy)
        {
            if(enemy.tag == "Enemy")
            {
                enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
            }
        }

        public override void UpgradeWeaponLevel()
        {
            SwingSword();

            Animator.speed *= 1.1f;
            attackDamage *= 1.2f;
            attackAnimationSpeed *= .9f;
            weaponLevel++;
        }
    }
}
