using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TA
{
    public class SetStat : MonoBehaviour
    {
        public SwordDamage SwordDamage;
        public WeaponAnimation SwordSwing;

        public float multiplier; 

        public void Upgrade()
        {
            SwordDamage.Damage *= multiplier;
            SwordSwing.attackAnimationSpeed *= multiplier;
        }

    }
}

