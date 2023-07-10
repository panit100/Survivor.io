using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenAttack : BaseAttack
{
    
    public float BasicAttackSpeed;
    public float Radius;
    public ShurikenProjectile Projectile;
    private float timer;
    
    private void Awake()
    {
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
            var AllEnemyInsight = GetEnemyInArea;
            for (int i = 0; i < AllEnemyInsight.Length; i++)
            {
                ShootClosestEnemy(AllEnemyInsight[i]);
            }
        }
    }
    
    public override void UpgradeWeaponLevel()
    {
        Debug.Log("upgrade");
        var tempRadius = Radius;
        var temptimer = BasicAttackSpeed;
        Radius = tempRadius*1.5f;
        if (BasicAttackSpeed > 0.1f)
        {
            BasicAttackSpeed = temptimer *0.95f;
        }
        weaponLevel++;
    }
    
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
        Collider2D nearestCollider = null;
        float minSqrDistance = Mathf.Infinity;
        bool isEnemy = enemyInsight.CompareTag("Enemy");
        if(isEnemy)
        {
            float sqrDistanceToCenter = (this.transform.position - enemyInsight.transform.position).sqrMagnitude;
            if (sqrDistanceToCenter < minSqrDistance)
            {
                minSqrDistance = sqrDistanceToCenter;
                nearestCollider = enemyInsight;
                spawnShuriken(nearestCollider.gameObject);
                return;
            }
        }
    }
    void spawnShuriken(GameObject target)
    {
        Projectile.Target = target;
        Instantiate(Projectile,this.transform.position,Quaternion.identity);
        timer = BasicAttackSpeed;
    }

    #endregion
    
    
}
