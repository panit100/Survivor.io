using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TA
{
    public class SetStat : MonoBehaviour
    {
        public int currentlevel = 0;
        public int Maxlevel;
        public UpgradeCardScriptableObject WeaponInfo;

        protected virtual void Start()
        {
            if (gameObject.activeInHierarchy) currentlevel = 1;
        }

        public virtual void StatSet()
        {
        
        }
    }
}

