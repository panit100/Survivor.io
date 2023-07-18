using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TA
{
    public class ShurikenAttack : BaseAttack
{
    public float damage = 5;
    public float bulletSpeed = 10;
    public float ShurikenCooldown;
    public float Radius;
    public ShurikenProjectile Projectile;
    [SerializeField] private GameObject WeaponPool;
    private float timer;
    
    
    private void Awake()
    {
        timer = ShurikenCooldown;
        if(!this.isActiveAndEnabled)weaponLevel = 0;
    }

    void Update()
    {
        DoShoot();
    }
    void DoShoot()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Collider2D[] AllEnemyInsight = GetEnemyInArea;
            Collider2D nearestCollider = null;
            for (int i = 0; i < AllEnemyInsight.Length; i++)
            {
                float minSqrDistance = Mathf.Infinity;
                bool isEnemy = AllEnemyInsight[i].CompareTag("Enemy");
                if(isEnemy)
                {
                    float sqrDistanceToCenter = (this.transform.position - AllEnemyInsight[i].transform.position).sqrMagnitude;
                    if (sqrDistanceToCenter < minSqrDistance)
                    {
                        minSqrDistance = sqrDistanceToCenter;
                        nearestCollider = AllEnemyInsight[i];
                        spawnShuriken(nearestCollider.gameObject);
                        return;
                    }
                }
            }
        }
    }
    
    // public override void UpgradeWeaponLevel()
    // {
    //     Debug.Log("upgrade");
    //     var tempRadius = Radius;
    //     var temptimer = ShurikenCooldown;
    //     Radius = tempRadius*1.5f;
    //     if (ShurikenCooldown > 0.1f)
    //     {
    //         ShurikenCooldown = temptimer *0.95f;
    //     }
    //     weaponLevel++;
    // }
    
    //Advance Method Logic 

    #region Blackmagic
    private Collider2D[] GetEnemyInArea
    {
        get
        {
            return Physics2D.OverlapCircleAll(this.transform.position, Radius);
        }
    }
    
    
    private void ShootClosestEnemy(Collider2D enemyInsight)
    {
       
       
    }

    void spawnShuriken(GameObject target)
    {
        Projectile.SetTarget(target);

        var projectile = Instantiate(Projectile,this.transform.position,Quaternion.identity);
        projectile.transform.SetParent(WeaponPool.transform);

        projectile.SetDamage(damage);
        projectile.SetSpeed(bulletSpeed);

        timer = ShurikenCooldown;
    }

    #endregion
    
    
}

}
