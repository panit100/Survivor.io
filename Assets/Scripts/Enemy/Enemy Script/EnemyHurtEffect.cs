using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TA
{

public class EnemyHurtEffect : MonoBehaviour
{
    SpriteRenderer SpriteRenderer;
    TA.EnemyHealth EnemyHealth;
    
    void Start()
    {
        SetupComponent();
        SetupSubscription();
    }
    void SetupComponent()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        EnemyHealth = GetComponent<TA.EnemyHealth>();
    }
    void SetupSubscription()
    {
        EnemyHealth.displayEffectEvent.AddListener(DisplayHurtEffect);
    }

    void DisplayHurtEffect()
    {
        StopCoroutine(DisplaySequence());
        StartCoroutine(DisplaySequence());
    }
    IEnumerator DisplaySequence()
    {
        SpriteRenderer.color = new Color(1,0,0,1);
        yield return new WaitForSeconds(0.185f);
        SpriteRenderer.color = new Color(1,1,1,1);
    }
}

}