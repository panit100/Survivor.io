using System.Collections;
using System.Collections.Generic;
using TA;
using UnityEngine;

namespace TA
{
    [CreateAssetMenu(fileName = "cardInfo",menuName = "UpgradeCard")]
    public class UpgradeCardScriptableObject : ScriptableObject
    {
        public Sprite image;
        public Vector3 imageSize;
        public string weaponName;
        public string description;
    }
}
