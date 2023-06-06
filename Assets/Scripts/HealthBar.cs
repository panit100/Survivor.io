using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBar;

    PlayerScript player;

    void Start()
    {
        player = GetComponent<PlayerScript>();
    }

    void Update()
    {
        healthBar.fillAmount = player.currentHealth / player.maxHealth;
    }
}
