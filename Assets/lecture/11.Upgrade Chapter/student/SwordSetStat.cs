using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TA
{
    public class SwordSetStat : SetStat
    {
        private DamageTrigger _damage;
        private WeaponAnimation _speed;
        public float multiplier;
        
        
        protected override void Start()
        {
            base.Start();
            _damage = GetComponent<DamageTrigger>();
            _speed = GetComponent<WeaponAnimation>();
        }

        public override void StatSet()
        {
            if(currentlevel>=Maxlevel) return;
            currentlevel += 1;
            // _damage.Damage *= multiplier;
            // _damage.Damage = Mathf.Clamp(_damage.Damage,10f,20f);
            _speed.attackAnimationSpeed *= multiplier;
            _speed.attackAnimationSpeed = Mathf.Clamp(_speed.attackAnimationSpeed,0.1f,2f);
            _speed.attackAnimationCooldown -= _speed.attackAnimationCooldown * 0.75f;
            _speed.attackAnimationCooldown = Mathf.Clamp(_speed.attackAnimationCooldown, 0.1f, _speed.attackAnimationCooldown);
        }
    }

}
