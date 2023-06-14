using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ThrowWeapon : MonoBehaviour
{
    public float KillTime;
    private Rigidbody2D thisRigidBody;
    void Start()
    {
        thisRigidBody = GetComponent<Rigidbody2D>();
        thisRigidBody.AddForce(new Vector2(Random.Range(-1f,1f),1f) * Random.Range(270f,500f));
        thisRigidBody.AddTorque(Random.Range(700f,1500f));
    }

    // Update is called once per frame
    void Update()
    {
        KillTime -= Time.deltaTime;
        if (KillTime < 0)
        {
            Destroy(this.gameObject);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            //Implement Enemy Taken Damage from player
            Destroy(col.gameObject);
            Destroy(this.gameObject);
        }
    }
}
