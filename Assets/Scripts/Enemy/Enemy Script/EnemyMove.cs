using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TA
{
    public class EnemyMove : MonoBehaviour
    {
        public float enemyMoveSpeedDefault;
        float enemyMoveSpeedCurrent;

        public Transform playerTransform;

        bool moveToPlayer = true;

        void Start()
        {
            enemyMoveSpeedCurrent = enemyMoveSpeedDefault;

            playerTransform = GameObject.FindWithTag("Player").transform;
        }

        void Update()
        {
            if(moveToPlayer)
                MoveToPlayer();
        }

        void MoveToPlayer()
        {
            Vector2 direction = playerTransform.position - transform.position;
            transform.Translate(direction.normalized * enemyMoveSpeedCurrent * Time.deltaTime);
        }

        void OnTriggerEnter2D(Collider2D other) 
        {
            if(other.tag == "Player")
            {
                StopMove();
            }
        }
        void OnTriggerExit2D(Collider2D other) 
        {
            if(other.tag == "Player")
            {
                ContinueMove();
            }
        }

        void StopMove()
        {
            enemyMoveSpeedCurrent = 0;
        }
        void ContinueMove()
        {
            enemyMoveSpeedCurrent = enemyMoveSpeedDefault;
        }
    }
}
