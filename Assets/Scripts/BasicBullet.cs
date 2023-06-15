using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : MonoBehaviour
{
    public float BulletSpeed;

    public GameObject Target;
    private Vector2 direction;
    private void Update()
    {
        LeapToEnemy();
    }

    public void LeapToEnemy()
    {
        if (Target != null)
        {
            direction = Target.transform.position - transform.position;
            transform.Translate((direction * BulletSpeed) * Time.deltaTime);
        }
        else
        {
            transform.Translate((direction * BulletSpeed) * Time.deltaTime);
            Invoke("DestroyThis",5f);
        }
        ;
    }

    void DestroyThis()
    {
        Destroy(this.gameObject);
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
