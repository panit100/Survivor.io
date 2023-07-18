using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TA
{
public class UpgradePanel : MonoBehaviour
{
    [SerializeField] List<UpgradeCard> cards = new List<UpgradeCard>();
    [SerializeField] PlayerWeapon playerWeapon;

    List<SetStat> tempRandomAttacks;

    public void SetCard()
    {
        gameObject.SetActive(true);

       
        if (playerWeapon.attacks.Count < cards.Count)
        {
            foreach (var VARIABLE in cards)
            {
                VARIABLE.gameObject.SetActive(false);
            }
            for (int i = 0; i < playerWeapon.attacks.Count; i++)
            {
                cards[i].gameObject.SetActive(true);
            }
        }
      
        RandomUpgradeWeapon();
        for(int i = 0; i < cards.Count; i++)
        {
            cards[i].SetCardInfo(tempRandomAttacks[i]);
        }
    }

    void RandomUpgradeWeapon()
    {
        tempRandomAttacks = new List<SetStat>();
    
        for(int i = 0; i < cards.Count; i++)
        {
            SetStat randomAttack = playerWeapon.attacks[Random.Range(0,playerWeapon.attacks.Count-1)];
            
            while(tempRandomAttacks.Count < cards.Count)
            {
                if(!tempRandomAttacks.Contains(randomAttack))
                    tempRandomAttacks.Add(randomAttack);
                else
                    randomAttack = playerWeapon.attacks[Random.Range(0,playerWeapon.attacks.Count-1)];
            }
        }
    }

    private void OnEnable()
    {
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }
}
}

