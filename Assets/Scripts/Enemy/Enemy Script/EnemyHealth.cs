using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TA
{
    public class EnemyHealth : MonoBehaviour
    {
        public float health = 10;
        public float currentHealth;
        public GameObject expItem;
        public EnemySpawner enemySpawner;

        [HideInInspector] public UnityEvent displayEffectEvent = new UnityEvent();


        void Start()
        {
            currentHealth = health;
        }

        public void TakeDamage(float damage)
        {
            currentHealth -= damage;
            displayEffectEvent.Invoke();

            if(currentHealth <= 0)
            {
                Instantiate(expItem,transform.position,Quaternion.identity);

                //Destroy(this.gameObject) //ใช้ก่อนสอน pooling 

                if(LayerMask.LayerToName(gameObject.layer) != "Boss")
                {
                    enemySpawner.enemyContainer.Remove(this.gameObject);
                }
                gameObject.SetActive(false);
            }
        }
    }
}
