using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAttack : MonoBehaviour
{
    protected int weaponLevel;

    public int WeaponLevel
    {
        get => weaponLevel;
        set => weaponLevel = value;
    }

    public UpgradeCardScriptableObject upgradeObject;

    public virtual void UpgradeWeaponLevel()
    {

    }
}
