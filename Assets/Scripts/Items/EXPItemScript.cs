using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TA
{
public class EXPItemScript : MonoBehaviour
{
    int expAmount = 10;
    PlayerScript player;

    public float lerpSpeed = 1f;

    public bool isMoveToPlayer = false; 

    float time = 0f;

    void Start() 
    {
        player = FindObjectOfType<PlayerScript>().GetComponent<PlayerScript>();    
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            player.PlayerLevel.GetExp(expAmount);

            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate() 
    {
        if(isMoveToPlayer)
            time = Time.deltaTime * lerpSpeed;
            
        LeapToPlayer();
    }

    public void LeapToPlayer()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position,time);
    }
}
    
}
