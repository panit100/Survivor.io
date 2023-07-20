using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TA
{
    public class EnemyMove : MonoBehaviour
    {
        public float enemyMoveSpeed;
        private float currentEnemyMoveSpeed;
        public Transform playerTransform;

        void Start()
        {
            currentEnemyMoveSpeed = enemyMoveSpeed;
            playerTransform = FindObjectOfType<PlayerMove>().transform;
        }

        void Update()
        {
            MoveToPlayer();
        }

        void MoveToPlayer()
        {
            Vector2 direction = playerTransform.position - transform.position;
            transform.Translate(direction.normalized * currentEnemyMoveSpeed * Time.deltaTime);
        }

        void StopMove()
        {
            currentEnemyMoveSpeed = 0;
        }

        void ContinueMove()
        {
            currentEnemyMoveSpeed = enemyMoveSpeed;
        }

        private void OnTriggerEnter2D(Collider2D other) 
        {
            if(other.tag == "Player")
            {
                StopMove();
            }
        }

        private void OnTriggerExit2D(Collider2D other) 
        {
            if(other.tag == "Player")
            {
                ContinueMove();
            }
        }
    }
}
