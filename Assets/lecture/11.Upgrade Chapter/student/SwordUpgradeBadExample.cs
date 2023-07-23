using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace TA
{
    public class SwordUpgradeBadExample : MonoBehaviour
    {
        public GameObject sword;
        private DamageTrigger _damage;
        private WeaponAnimation _animationSpeed;
        private int _weaponLevel;

        public UpgradeCardScriptableObject cardinfo;
        void Start()
        {
            findsword();
        }

        void InitLevel()
        {
            
        }

        void findsword()
        {
            DamageTrigger[] tempobjects = FindObjectsOfType<DamageTrigger>();
            if(tempobjects is null) return;
            foreach (var I in tempobjects)
            {
                if (I.gameObject.name.Contains("SwordAttack"))
                {
                    sword = I.gameObject;
                    _damage = I.GetComponent<DamageTrigger>();
                    _animationSpeed = I.GetComponent<WeaponAnimation>();
                }
            }
        }

        private void getStat()
        {
            
        }

        private void UpgradeSword()
        {
        //    _damage.Damage *= 1.15f;
        }
    }

}
