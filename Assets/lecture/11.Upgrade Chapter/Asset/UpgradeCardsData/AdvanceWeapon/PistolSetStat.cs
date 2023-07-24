using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TA
{
    public class PistolSetStat : SetStat
    {
        PistolShootAttack pistolShootAttack;
        public float multiplier;

        override protected void Start()
        {
            base.Start();
            pistolShootAttack = GetComponent<PistolShootAttack>();
        }

        public override void StatSet()
        {
            pistolShootAttack.attackCooldown *= 0.9f;
            pistolShootAttack.attackCooldown = Mathf.Clamp(pistolShootAttack.attackCooldown,1f,3f);

            pistolShootAttack.attackDamage *= multiplier;
            pistolShootAttack.attackDamage = Mathf.Clamp(pistolShootAttack.attackDamage,5f,10f);

            pistolShootAttack.attackRange *= 1.05f;
            pistolShootAttack.attackRange = Mathf.Clamp(pistolShootAttack.attackRange,1f,5f);

            pistolShootAttack.shootInterval *= 0.9f;
            pistolShootAttack.shootInterval = Mathf.Clamp(pistolShootAttack.shootInterval,.1f,.5f);
        }
    }
}
