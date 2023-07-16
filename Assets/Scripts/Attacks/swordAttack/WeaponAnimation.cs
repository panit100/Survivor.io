using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnimation : MonoBehaviour
{
    [SerializeField] private GameObject SpriteHolder;
    public float attackAnimationCooldown = 1f;
    public float attackAnimationSpeed = 1f;
    private Animator Animator;
  
    void Start()
    {
        SetupComponent();
    }
    private void SetupComponent()
    {
        Animator = SpriteHolder.GetComponent<Animator>();
        SpriteHolder.SetActive(false);
        Animator.speed = attackAnimationSpeed;
    }
    private void SwingSword()
    {
        StopAllCoroutines();
        StartCoroutine(SwingSwordSequence());
    }
    private IEnumerator SwingSwordSequence()
    {
        SpriteHolder.SetActive(true);

        yield return new WaitForSeconds(attackAnimationSpeed);
        SpriteHolder.SetActive(false);

        yield return new WaitForSeconds(attackAnimationCooldown);
        SwingSword();
    }

}
