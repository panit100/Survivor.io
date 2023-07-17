using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace TA
{
    public class PlayerLevelUI : MonoBehaviour
    {
        public TextMeshProUGUI leveltext;
        public Image levelBarFill;

        PlayerLevelController playerLevelController;

        // Start is called before the first frame update
        void Start()
        {
            playerLevelController = FindObjectOfType<PlayerLevelController>().GetComponent<PlayerLevelController>();

            levelBarFill.fillAmount = 0; 
            leveltext.text = playerLevelController.currentLevel.ToString();
        }

        private void Update()
        {
            UpdateLevelBarMonitor();
        }

        private void UpdateLevelBarMonitor()
        {
            leveltext.text = playerLevelController.currentLevel.ToString();
            levelBarFill.fillAmount = (float)playerLevelController.exp / (float)playerLevelController.maxExp;
        }
    }
}
