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

   private void Start()
   {
      upgradePanel = FindObjectOfType<UpgradePanel>();
   }

   public void BasicAttack()
   {
      Weapon.GetComponent<BasicAttack>().UpgradeWeaponLevel();
      Level.text = "LV. :" + (Weapon.GetComponent<BasicAttack>().WeaponLevel+1);
      upgradePanel.gameObject.SetActive(false);
   }

   public void OrbitAttack()
   {
      Weapon.GetComponent<OrbitAttack>().UpgradeWeaponLevel();
      Level.text = "LV. :" + (Weapon.GetComponent<OrbitAttack>().WeaponLevel+1);
      upgradePanel.gameObject.SetActive(false);
   }

   public void ThrowAttack()
   {
      Weapon.GetComponent<ThrowAttack>().UpgradeWeaponLevel();
      Level.text = "LV. :" + (Weapon.GetComponent<ThrowAttack>().WeaponLevel+1);
      upgradePanel.gameObject.SetActive(false);
   }
}
