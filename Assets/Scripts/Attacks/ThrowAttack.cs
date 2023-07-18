using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TA
{
    public class ThrowAttack : BaseAttack
    {
        public float damage = 5;
        public float ThrowAttackCoolDownspeed;
        public int ThrowCount;
        public ThrowWeapon Axe;
        
        private float timer;

        private void Awake()
        {
            if(!this.isActiveAndEnabled)weaponLevel = 0;
        }


        private void Start()
        {
            timer = ThrowAttackCoolDownspeed;
        }

        void FixedUpdate()
        {
            DoShoot();
        }
        void DoShoot()
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                StartCoroutine(SpawnAxes());
                timer = ThrowAttackCoolDownspeed;
                return;
            }
        }

        IEnumerator SpawnAxes()
        {
            for (int i = 0; i < ThrowCount; i++)
            {
                ThrowWeapon throwWeapon = Instantiate(Axe,this.transform.position,Quaternion.identity);
                throwWeapon.SetDamage(damage);
                yield return new WaitForSeconds(0.5f);
            }
        }

        // public override void UpgradeWeaponLevel()
        // {
        //     if (weaponLevel == 0)
        //     {
        //         this.gameObject.SetActive(true);
        //     }
        //     else
        //     {
        //         var temptimer = timer;
        //         if (ThrowCount < 5)
        //         {
        //             ThrowCount++;
        //         }
        //         if (timer > 0.1f)
        //         {
        //             timer = temptimer / 4;
        //         }
        //     }
        //     weaponLevel++;
        // }
    
    }
}

