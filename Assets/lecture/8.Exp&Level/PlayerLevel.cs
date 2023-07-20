using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TA
{
    public class PlayerLevel : MonoBehaviour
    {
        public int currentLevel = 1;

        public int exp = 0;
        public int maxExp;

        public void LevelUp()
        {
            exp = 0;
            currentLevel++;
        }

        public void GetExp(int amount)
        {
            exp += amount;

            if(exp >= maxExp)
            {
                maxExp = Mathf.RoundToInt(maxExp * 1.25f);
                LevelUp();
            }
        }
    }
}
