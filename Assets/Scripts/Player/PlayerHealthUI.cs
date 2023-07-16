using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    public Image healthBarFill;

    PlayerHealth PH;

    void Start()
    {
        SetupComponent();
    }
    void SetupComponent()
    {
        PH = GetComponent<PlayerHealth>();
    }

    void Update()
    {
        UpdateHP();
    }
    void UpdateHP()
    {
        if(healthBarFill == null) 
        {
            Debug.Log("ใส่หลอดเลือดด้วยจ้า");
            return; 
        }

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
