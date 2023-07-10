using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItemScript : MonoBehaviour
{
    int healAmount = 10;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            PlayerScript player = other.GetComponent<PlayerScript>();
            
            player.PlayerHealth.Heal(healAmount);
            Destroy(this.gameObject);
        }
    }
}
