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

        PlayerLevel playerLevelController;

        // Start is called before the first frame update
        void Start()
        {
            //Uncomment When PlayerLevel Finish

            // playerLevelController = FindObjectOfType<PlayerLevel>().GetComponent<PlayerLevel>();

            // levelBarFill.fillAmount = 0; 
            // leveltext.text = playerLevelController.currentLevel.ToString();
        }

        private void Update()
        {
            UpdateLevelBarMonitor();
        }

        private void UpdateLevelBarMonitor()
        {
             //Uncomment When PlayerLevel Finish
             
            // leveltext.text = playerLevelController.currentLevel.ToString();
            // levelBarFill.fillAmount = (float)playerLevelController.exp / (float)playerLevelController.maxExp;
        }
    }
}
