using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkillRegenHealth : MonoBehaviour
{
    public float regenValue;
    public float regenEverySecond;

    TA.EnemyHealth EnemyHealth;

    private void Start()
    {
        SetupComponent();
        InvokeRepeating("RegenHealth", 0f, regenEverySecond);
    }
    private void SetupComponent()
    {
        EnemyHealth = GetComponent<TA.EnemyHealth>();
    }
    private void RegenHealth()
    {
        if(EnemyHealth.currentHealth >= EnemyHealth.health)
        {
            EnemyHealth.currentHealth = EnemyHealth.health;
        }
        else
        {
            EnemyHealth.currentHealth += regenValue;
        }
    }
}