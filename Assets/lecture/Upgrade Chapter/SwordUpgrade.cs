using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace TA
{
    public class SwordUpgrade : MonoBehaviour
    {
        public GameObject Sword;
        private DamageTrigger _damage;
        private WeaponAnimation _animationspeed;
        private int WeaponLevel;

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
                    Sword = I.gameObject;
                    _damage = I.GetComponent<DamageTrigger>();
                    _animationspeed = I.GetComponent<WeaponAnimation>();
                }
            }
        }

        private void getStat()
        {
            
        }

        private void UpgradeSword()
        {
            _damage.Damage *= 1.15f;
        }
    }

}
