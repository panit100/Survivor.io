using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TA
{
    public class ShurikenProjectile : MonoBehaviour
{
    [Header("Shuriken Configuration")] 
    public float BulletSpeed;
    public GameObject Target;
    public float damage = 5;

    [Header("Animation Adjustment")] 
    [SerializeField] private float Fadetime;
    
    //private variable 
    private Vector2 direction;
    private SpriteRenderer thisSprite;
    private Color tempColor;
    private Vector3 lastdirection;
    private Vector3 StartPos;
    private Coroutine NullTarget;
    private ExitReposition targetRepos;
    [SerializeField ]private bool Targetisdead = false;

    private void Start()
    {
        targetRepos = Target.GetComponent<ExitReposition>();
        StartPos = transform.position;
        lastdirection =  transform.position -Target.transform.position;
        SetUpSpriteColor();
        StartCoroutine(FadeIn());
    }

    private void SetUpSpriteColor()
    {
        thisSprite = GetComponent<SpriteRenderer>();
        tempColor = thisSprite.color;
        tempColor.a = 0;
        thisSprite.color = tempColor;
    }

    private void Update()
    {
        if (targetRepos.hasRepos)
        {
            Targetisdead = true;
        }
        LeapToEnemy();
    }

    public void LeapToEnemy()
    {
        if (Target.activeInHierarchy && !Targetisdead)
        {
            direction =  Target.transform.position -StartPos ;
            transform.Translate(direction.normalized*BulletSpeed*Time.deltaTime);
        }
        else
        {
            if (NullTarget == null) NullTarget = StartCoroutine(FadeOutAndDestroy());
            transform.position -=lastdirection.normalized * BulletSpeed * Time.deltaTime;
        }
        ;
    }

    void DestroyThis()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            //Implement Enemy Taken Damage from player
            col.GetComponent<EnemyScript>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }

    IEnumerator FadeIn()
    {
        while(thisSprite.color.a <1)
        {
            tempColor.a = Mathf.Clamp01(tempColor.a+Time.deltaTime*2.5f) ;
            thisSprite.color = tempColor;
            yield return null;
        }
    }

    IEnumerator FadeOutAndDestroy()
    {
        float a = thisSprite.color.a;
        tempColor = thisSprite.color;
        while(a>0f)
        {
            a -=Time.deltaTime*0.5f ;
            tempColor.a = Mathf.Clamp01(a);
            thisSprite.color = tempColor;
            Debug.Log("Alpha"+ a);
            yield return null;
        }
        DestroyThis();
        NullTarget = null;
        yield return null;
    }
}

}
