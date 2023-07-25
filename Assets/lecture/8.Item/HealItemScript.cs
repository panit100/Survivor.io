using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TA
{
    public class HealItemScript : MonoBehaviour
    {
        int healAmount = 10;

        private void OnTriggerEnter2D(Collider2D other) 
        {
            if(other.CompareTag("Player"))
            {
                PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
                
                playerHealth.Heal(healAmount);
                Destroy(this.gameObject);
            }
        }
    }
}
