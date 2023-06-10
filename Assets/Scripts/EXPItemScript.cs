using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXPItemScript : MonoBehaviour
{
    int expAmount = 10;
    PlayerScript player;

    public bool isMoveToPlayer = false; 

    void Start() 
    {
        player = FindObjectOfType<PlayerScript>().GetComponent<PlayerScript>();    
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            player.exp += expAmount;

            Destroy(this.gameObject);
        }
    }

    private void Update() 
    {
        if(isMoveToPlayer)
            LeapToPlayer();
    }

    public void LeapToPlayer()
    {
        Vector2 direction = player.transform.position - transform.position;

        transform.Translate(direction * 1.5f * Time.deltaTime);

        // transform.position = Vector2.Lerp(transform.position,player.transform.position,Time.deltaTime);
    }
}
