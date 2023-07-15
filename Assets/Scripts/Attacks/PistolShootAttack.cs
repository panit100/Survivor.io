using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TA
{
    public class PistolShootAttack : BaseAttack
{
    [SerializeField] private float attackCooldown = 3f;
    [SerializeField] private float attackDamage = 5f;
    [SerializeField] private float attackRange = 1f;
    [SerializeField] private float shootInterval = 0.5f;
    [SerializeField] private LayerMask targetLayerMask;
    [SerializeField] private GameObject gunHolder;
    [SerializeField] private GameObject gunLightHolder;

    private void Start()
    {
        ActiveWeapon();
    }
    private void ActiveWeapon()
    {
        GetEnemyInCircle();
        gunHolder.SetActive(false);
        gunLightHolder.SetActive(false);
    }

    private void GetEnemyInCircle()
    {
        Collider2D[] enemyInCircleRange;
        enemyInCircleRange = Physics2D.OverlapCircleAll(transform.position, attackRange, targetLayerMask);
        StopAllCoroutines();
        StartCoroutine(DamageEnemyInCircle(enemyInCircleRange));
    }
    private IEnumerator DamageEnemyInCircle(Collider2D[] enemies)
    {
        foreach(Collider2D enemy in enemies)
        {
            enemy.GetComponent<EnemyScript>().TakeDamage(attackDamage);
            gunHolder.SetActive(true);
            gunLightHolder.SetActive(true);
            yield return new WaitForSeconds(0.05f);
            gunLightHolder.SetActive(false);
            yield return new WaitForSeconds(shootInterval);
            gunHolder.SetActive(false);
        }
        yield return new WaitForSeconds(attackCooldown);
        GetEnemyInCircle();
    }
    private void OnDrawGizmos() 
    {
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    public override void UpgradeWeaponLevel()
    {
        attackRange *= 1.1f;
        attackDamage *= 1.2f;
        attackCooldown *= 0.9f;
        weaponLevel++;
    }
}
}

