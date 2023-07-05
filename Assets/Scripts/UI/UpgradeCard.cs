using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeCard : MonoBehaviour
{
   public UpgradeCardScriptableObject upgradeCardInfo;
   public Image image;
   public TMP_Text name;
   public TMP_Text info;
   public TMP_Text level;
   
   
   public GameObject Weapon;
   public UpgradePanel upgradePanel;

   [SerializeField]private BasicAttack _basicAttack;
   [SerializeField]private OrbitAttack _orbitAttack;
   [SerializeField]private ThrowAttack _throwAttack;

   private void Start()
   {
      upgradePanel = FindObjectOfType<UpgradePanel>();

      SetCardInfo();
   }

   void SetCardInfo()
   {
      image.sprite = upgradeCardInfo.image;
      image.SetNativeSize();
      image.transform.localScale = upgradeCardInfo.imageSize;
      name.text = upgradeCardInfo.name;
      info.text = upgradeCardInfo.description;
   }

   public void BasicAttack()
   {
      _basicAttack.UpgradeWeaponLevel();
      level.text = "LV. :" + (_basicAttack.WeaponLevel+1);
      upgradePanel.gameObject.SetActive(false);
   }

   public void OrbitAttack()
   {
      _orbitAttack.UpgradeWeaponLevel();
      level.text = "LV. :" + (_orbitAttack.WeaponLevel+1);
      upgradePanel.gameObject.SetActive(false);
   }

   public void ThrowAttack()
   {
      _throwAttack.UpgradeWeaponLevel();
      level.text = "LV. :" + (_throwAttack.WeaponLevel+1);
      upgradePanel.gameObject.SetActive(false);
   }

   public void Heal()
   {

   }
}
