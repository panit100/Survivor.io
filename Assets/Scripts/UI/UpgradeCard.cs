using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

   public void SetCardInfo(BaseAttack baseAttack)
   {
      UpgradeButton.onClick.RemoveAllListeners();

      image.sprite = baseAttack.upgradeObject.image;
      image.SetNativeSize();
      image.transform.localScale = baseAttack.upgradeObject.imageSize;
      name.text = baseAttack.upgradeObject.name;
      info.text = baseAttack.upgradeObject.description;
      level.text = "LV. :" + (baseAttack.WeaponLevel);

      UpgradeButton.onClick.AddListener(baseAttack.UpgradeWeaponLevel);
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
