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

   private void Start()
   {
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
      level.text = "LV. :" + (baseAttack.WeaponInfo);
      
      baseAttack.gameObject.SetActive(true);
      
      UpgradeButton.onClick.AddListener(baseAttack.StatSet);
      UpgradeButton.onClick.AddListener(ClosePanel);
   }
   
   void ClosePanel()
   {
      upgradePanel.gameObject.SetActive(false);
   }

   public void Heal()
   {

   }
}
}

