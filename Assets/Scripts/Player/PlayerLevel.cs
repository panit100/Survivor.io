using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerLevel : MonoBehaviour
{
    [Header("LEVEL")]
    [SerializeField] int maxExp;
    int exp = 0;
    int currentLevel = 1;

    [Header("UI")]
    public TextMeshProUGUI leveltext;
    public Image levelbar;
    public UpgradePanel upgradePanel;

    void Start() 
    {
        exp = 0;   
        levelbar.fillAmount = 0; 
        leveltext.text = currentLevel.ToString();
    }

    public void LevelUp()
    {
        exp = 0;
        currentLevel++;
        levelbar.fillAmount = 0;

        upgradePanel.SetCard();
        leveltext.text = currentLevel.ToString();
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

    private void Update()
    {
        UpdateLevelBarMonitor();
    }

    private void UpdateLevelBarMonitor()
    {
        float fillamount = (exp / maxExp) ;
        levelbar.fillAmount = fillamount;
    }
}
