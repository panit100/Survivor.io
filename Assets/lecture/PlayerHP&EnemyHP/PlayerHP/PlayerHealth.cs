using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TA
{
    public class PlayerHealth : MonoBehaviour
    {
        public float maxHealth = 10f;
        public float currentHealth = 0f;

        void Start()
        {
            currentHealth = maxHealth;
            Time.timeScale = 1;
        }

        public void TakeDamage(float damage)
        {
            // เพิ่มการคำนวณความเสียหาย: HP ของผู้เล่นถูกลดด้วยพลังโจมตีศัตรู
            currentHealth -= damage;
        }

        public void Heal(float amount)
        {
            // เพิ่มพลังชีวิตขึ้นมาด้วย
            currentHealth += amount;

            if(currentHealth > maxHealth)
                currentHealth = maxHealth;
        }
    }
}