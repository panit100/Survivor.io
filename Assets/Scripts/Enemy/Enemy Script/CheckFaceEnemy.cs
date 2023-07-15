using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TA
{
    public class CheckFaceEnemy : MonoBehaviour
    {
        public Transform playerTransform;

        SpriteRenderer sprite;

        // Start is called before the first frame update
        void Start()
        {
            if(GetComponent<SpriteRenderer>() != null)
            {
                sprite = GetComponent<SpriteRenderer>();
            }

            playerTransform = GameObject.FindWithTag("Player").transform;
        }

        // Update is called once per frame
        void Update()
        {
            CheckEnemyFacing();
        }

        void CheckEnemyFacing()
        {
            if(sprite == null)
            {
                if(transform.position.x > playerTransform.position.x)
                {
                    transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x) * -1, transform.localScale.y);
                }
                else if(transform.position.x < playerTransform.position.x)
                {
                    transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
                }
            }
            else
            {
                if(transform.position.x > playerTransform.position.x)
                {
                    sprite.flipX = true;
                }
                else if(transform.position.x < playerTransform.position.x)
                {
                    sprite.flipX = false;
                }
            }
        }
    }
}
