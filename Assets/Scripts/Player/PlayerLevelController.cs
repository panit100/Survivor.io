using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace TA
{
public class PlayerLevelController : MonoBehaviour
{
    [Header("Level")]
    [SerializeField] int maxExp;
    int exp = 0;
    int currentLevel = 1;

    [Header("UI")]
    public Transform playerLevelUI;
    TextMeshProUGUI leveltext;
    Image levelBarFill;

    [Header("Upgrade Panel")]
    public UpgradePanel upgradePanel;

    void Start() 
    {
        SetupUI();
        SetupVariable();
    }
    void SetupUI()
    {
        leveltext = GameObject.Find("Level Text").GetComponent<TextMeshProUGUI>();
        levelBarFill = GameObject.Find("EXP Bar FIll").GetComponent<Image>();        
    }
    void SetupVariable()
    {
        exp = 0;   
        levelBarFill.fillAmount = 0; 
        leveltext.text = currentLevel.ToString();
    }

    private void Update()
    {
        UpdateLevelBarMonitor();
    }

    public void LevelUp()
    {
        exp = 0;
        currentLevel++;
        levelBarFill.fillAmount = 0;

        leveltext.text = currentLevel.ToString();
        
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

    private void UpdateLevelBarMonitor()
    {
        levelBarFill.fillAmount = (float)exp / (float)maxExp;
    }
}

}
