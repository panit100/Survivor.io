using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TA
{
    public class ThrowSetStat : SetStat
    {
        ThrowAttack throwAttack;
        public float multiplier;

        override protected void Start()
        {
            base.Start();
            throwAttack = GetComponent<ThrowAttack>();
        }

        public override void StatSet()
        {
            throwAttack.damage *= multiplier;
            throwAttack.damage = Mathf.Clamp(throwAttack.damage,5f,20f);
            throwAttack.ThrowCount = (int)Mathf.Clamp(throwAttack.damage/3,3,7);
            throwAttack.ThrowAttackCoolDownspeed *= 0.9f;
            throwAttack.ThrowAttackCoolDownspeed = Mathf.Clamp(throwAttack.ThrowAttackCoolDownspeed,3f,7f);
        }
    }
}
