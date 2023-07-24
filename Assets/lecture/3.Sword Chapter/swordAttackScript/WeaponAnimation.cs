using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TA
{
    public class WeaponAnimation : MonoBehaviour
    {
        public float attackAnimationCooldown = 1f;
        public float attackAnimationSpeed = 1f;
        [SerializeField] private Animator animator;
    
        void Start()
        {
            SetupComponent();
            SwingSword();
        }

        private void Update()
        {
            animator.speed = attackAnimationSpeed;
        }

        private void SetupComponent()
        {
            animator.gameObject.SetActive(false);
            animator.speed = attackAnimationSpeed;
        }
        private void SwingSword()
        {
            StopAllCoroutines();
            StartCoroutine(SwingSwordSequence());
        }
        private IEnumerator SwingSwordSequence()
        {
            animator.gameObject.SetActive(true);
            yield return new WaitForSeconds(1f/attackAnimationSpeed);
            animator.gameObject.SetActive(false);
            yield return new WaitForSeconds(attackAnimationCooldown);
            SwingSword();
        }
    }
}
