using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TA
{
    public class ShotgunSetStat : SetStat
    {
        ShotgunAttack shotgunAttack;
        public float multiplier;

        override protected void Start()
        {
            base.Start();
            shotgunAttack = GetComponent<ShotgunAttack>();
        }

        public override void StatSet()
        {
            shotgunAttack.bulletDamage *= multiplier;
            shotgunAttack.bulletDamage = Mathf.Clamp(shotgunAttack.bulletDamage,8f,20f);

            shotgunAttack.bulletTotal = (int)Mathf.Clamp(shotgunAttack.bulletDamage/3,5,10);

            shotgunAttack.shootCooldown *= 0.9f;
            shotgunAttack.shootCooldown = Mathf.Clamp(shotgunAttack.shootCooldown,0.5f,2f);
        }        
        
    }
}
