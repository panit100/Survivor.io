using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TA
{
public class UpgradeCard : MonoBehaviour
{
   public Image image;
   public TMP_Text name;
   public TMP_Text info;
   public TMP_Text level;
   public Button UpgradeButton;
   
   public UpgradePanel upgradePanel;

   private PlayerHealth _health;

   private void Start()
   {
      _health = FindObjectOfType<PlayerHealth>();
      upgradePanel = FindObjectOfType<UpgradePanel>();
   }

   public void SetCardInfo(SetStat baseAttack)
   {
      UpgradeButton.onClick.RemoveAllListeners();
      
      image.sprite = baseAttack.WeaponInfo.image;
      image.SetNativeSize();
      image.transform.localScale = baseAttack.WeaponInfo.imageSize;
      name.text = baseAttack.WeaponInfo.name;
      info.text = baseAttack.WeaponInfo.description;
      level.text = "LV. :" + (baseAttack.currentlevel);
      
      baseAttack.gameObject.SetActive(true);
      
      UpgradeButton.onClick.AddListener(baseAttack.StatSet);
      UpgradeButton.onClick.AddListener(ClosePanel);
   }

   public void SetCardHP(UpgradeCardScriptableObject hpcardINFO)
   {
      UpgradeButton.onClick.RemoveAllListeners();
      image.sprite = hpcardINFO.image;
      image.SetNativeSize();
      image.transform.localScale = hpcardINFO.imageSize;
      name.text =hpcardINFO.name;
      info.text = hpcardINFO.description;
      level.text = "";
      UpgradeButton.onClick.AddListener(Heal);
      UpgradeButton.onClick.AddListener(ClosePanel);
   }
   
   void ClosePanel()
   {
      upgradePanel.gameObject.SetActive(false);
   }

   public void Heal()
   {
      _health.Heal(Mathf.Clamp(_health.maxHealth/2f,0,_health.maxHealth));
   }
}
}

