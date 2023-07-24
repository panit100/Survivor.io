using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TA
{
    public class PlayerHealthUI : MonoBehaviour
    {
        Image healthBarFill;
        PlayerHealth playerHealth;

        void Start()
        {
            SetupComponent();
            SetupUI();
        }
        void SetupComponent()
        {
            playerHealth = FindObjectOfType<PlayerHealth>().GetComponent<PlayerHealth>();
        }
        void SetupUI()
        {
            healthBarFill = transform.Find("HPBar").GetComponent<Image>();
        }

        void Update()
        {
            UpdateHP();
        }
        
        void UpdateHP()
        {
            if(playerHealth.currentHealth > 0)
            {
                healthBarFill.fillAmount = playerHealth.currentHealth / playerHealth.maxHealth;
            }
            else
            {
                healthBarFill.fillAmount = 0;
            }
        }
    }
}