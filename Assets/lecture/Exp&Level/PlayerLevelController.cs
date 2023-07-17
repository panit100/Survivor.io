using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TA
{
    public class PlayerLevelController : MonoBehaviour
    {
        [Header("Level")]
        public int maxExp;
        public int exp = 0;
        public int currentLevel = 1;

        [Header("Upgrade Panel")]
        public UpgradePanel upgradePanel; //เพิ่มเข้าไปทีหลังตอน Upgrade

        public void LevelUp()
        {
            exp = 0;
            currentLevel++;
            
            //เพิ่มเข้าไปทีหลังตอน Upgrade
            if(upgradePanel != null)
            {
                upgradePanel.SetCard();
            }
        }

        public void GetExp(int amount)
        {
            exp += amount;

            if (exp >= maxExp)
            {
                maxExp = Mathf.RoundToInt(maxExp*1.25f) ;
                LevelUp();
            }
        }
    }

}
