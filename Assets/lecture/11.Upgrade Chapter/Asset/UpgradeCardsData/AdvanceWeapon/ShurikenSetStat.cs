using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TA
{
    public class ShurikenSetStat : SetStat
    {
        ShurikenAttack shurikenAttack;
        public float multiplier;
        override protected void Start()
        {
            base.Start();
            shurikenAttack = GetComponent<ShurikenAttack>();
        }

        public override void StatSet()
        {
            shurikenAttack.damage *= multiplier;
            shurikenAttack.damage = Mathf.Clamp(shurikenAttack.damage,5f,10f);
            shurikenAttack.bulletSpeed *= multiplier;
            shurikenAttack.bulletSpeed = Mathf.Clamp(shurikenAttack.bulletSpeed,10f,20f);
            shurikenAttack.ShurikenCooldown *= 0.9f;
            shurikenAttack.ShurikenCooldown = Mathf.Clamp(shurikenAttack.ShurikenCooldown,5f,10f);
            shurikenAttack.Radius *= 1.05f;
            shurikenAttack.Radius = Mathf.Clamp(shurikenAttack.Radius,3f,5f);
        }
    }
}
