using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TA
{
    public class WeaponAnimation : MonoBehaviour
    {
        public float attackAnimationCooldown = 1f;
        public float attackAnimationSpeed = 1f;
        [SerializeField] private Animator Animator;
    
        void Start()
        {
            SetupComponent();
            SwingSword();
        }
        private void SetupComponent()
        {
            Animator.gameObject.SetActive(false);
            Animator.speed = attackAnimationSpeed;
        }
        private void SwingSword()
        {
            StopAllCoroutines();
            StartCoroutine(SwingSwordSequence());
        }
        private IEnumerator SwingSwordSequence()
        {
            Animator.gameObject.SetActive(true);

            yield return new WaitForSeconds(attackAnimationSpeed);
            Animator.gameObject.SetActive(false);

            yield return new WaitForSeconds(attackAnimationCooldown);
            SwingSword();
        }
    }
}
