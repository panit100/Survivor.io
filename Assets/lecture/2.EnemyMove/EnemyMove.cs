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

        void Start()
        {
            enemyMoveSpeedCurrent = enemyMoveSpeedDefault;

            playerTransform = GameObject.FindWithTag("Player").transform;  
        }

        void Update()
        {
            MoveToPlayer();
        }

        void MoveToPlayer()
        {
            Vector2 direction = playerTransform.position - transform.position;
            transform.Translate(direction.normalized * enemyMoveSpeedCurrent * Time.deltaTime);
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
