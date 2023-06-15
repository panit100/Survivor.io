using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowAttack : MonoBehaviour
{
    
    public float ThrowAttackCoolDownspeed;
    public int ThrowCount;
    public ThrowWeapon Axe;
    private float timer;


    private void Start()
    {
        timer = ThrowAttackCoolDownspeed;
    }

    void Update()
    {
        DoShoot();
    }
    void DoShoot()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            StartCoroutine(SpawnAxes());
            timer = ThrowAttackCoolDownspeed;
            return;
        }
    }

    IEnumerator SpawnAxes()
    {
        for (int i = 0; i < ThrowCount; i++)
        {
            Instantiate(Axe,this.transform.position,Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }
    }
   
}
