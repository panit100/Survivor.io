using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TA
{
    public class HealItemScript : MonoBehaviour
    {
        public int healAmount;

        private void OnTriggerEnter2D(Collider2D other) 
        {
            if(other.CompareTag("Player"))
            {
                other.GetComponent<PlayerHealth>().Heal(healAmount);

                Destroy(gameObject);
            }
        }
    }
}
