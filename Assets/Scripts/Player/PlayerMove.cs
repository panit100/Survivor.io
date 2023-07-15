using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TA
{
    public class PlayerMove : MonoBehaviour
    {
        public float speed = 10f;

        public Vector2 direction;

        void Update()
        {
            GetDirection();
            Move();
        }

        void GetDirection()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            direction = new Vector2(horizontal,vertical).normalized;
        }

        void Move()
        {
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }
}

