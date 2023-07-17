using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TA
{
public class EXPItemScript : MonoBehaviour
{
    int expAmount = 10;
    PlayerLevelController playerLevel;

    public float lerpSpeed = 1f;

    public bool isMoveToPlayer = false; 

    float time = 0f;

    void Start() 
    {
        playerLevel = FindObjectOfType<PlayerLevelController>().GetComponent<PlayerLevelController>();    
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            playerLevel.GetExp(expAmount);

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
        transform.position = Vector3.Lerp(transform.position, playerLevel.transform.position,time);
    }
}
    
}
