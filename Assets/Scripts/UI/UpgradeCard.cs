using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeCard : MonoBehaviour
{
   public TextMeshProUGUI Level;
   public GameObject Weapon;
   public UpgradePanel upgradePanel;

   [SerializeField]private BasicAttack _basicAttack;
   [SerializeField]private OrbitAttack _orbitAttack;
   [SerializeField]private ThrowAttack _throwAttack;

   private void Start()
   {
      upgradePanel = FindObjectOfType<UpgradePanel>();
   }

   public void BasicAttack()
   {
      _basicAttack.UpgradeWeaponLevel();
      Level.text = "LV. :" + (_basicAttack.WeaponLevel+1);
      upgradePanel.gameObject.SetActive(false);
   }

   public void OrbitAttack()
   {
      _orbitAttack.UpgradeWeaponLevel();
      Level.text = "LV. :" + (_orbitAttack.WeaponLevel+1);
      upgradePanel.gameObject.SetActive(false);
   }

   public void ThrowAttack()
   {
      _throwAttack.UpgradeWeaponLevel();
      Level.text = "LV. :" + (_throwAttack.WeaponLevel+1);
      upgradePanel.gameObject.SetActive(false);
   }
}
