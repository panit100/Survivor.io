using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSword : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Enemy")
        {
          other.GetComponent<TA.EnemyHealth>().TakeDamage(5f);
        }
        
    }
}
