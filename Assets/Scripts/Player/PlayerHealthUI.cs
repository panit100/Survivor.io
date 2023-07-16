using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    public GameObject playerHealthUI; 
    Image healthBarFill;
    PlayerHealth PH;

    void Start()
    {
        SetupComponent();
        SetupUI();
    }
    void SetupComponent()
    {
        PH = GetComponent<PlayerHealth>();
    }
    void SetupUI()
    {
        healthBarFill = playerHealthUI.transform.Find("Health Bar Fill").GetComponent<Image>();
    }

    void Update()
    {
        UpdateHP();
    }
    void UpdateHP()
    {
        if(PH.currentHealth > 0)
        {
            healthBarFill.fillAmount = PH.currentHealth / PH.maxHealth;
        }
        else
        {
            healthBarFill.fillAmount = 0;
        }
    }
}