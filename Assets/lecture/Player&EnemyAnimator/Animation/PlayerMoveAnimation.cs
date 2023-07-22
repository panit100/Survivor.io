using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TA
{
    public class PlayerMoveAnimation : MonoBehaviour
    {
        PlayerMove playerMove;
        public Animator animator;

        void Start()
        {
            playerMove = GetComponent<PlayerMove>();
        }

        void Update()
        {
            MoveAnimation();
        }

        void MoveAnimation()
        {
            //Uncomment when PlayerMove.cs Finish

            // if(playerMove.direction.x > 0)
            // {
            //     animator.SetBool("Walk", true);
            //     animator.transform.localScale = new Vector2(Mathf.Abs(animator.transform.localScale.x), animator.transform.localScale.y);
            // }
            // else if(playerMove.direction.x < 0)
            // {
            //     animator.SetBool("Walk", true);
            //     animator.transform.localScale = new Vector2(Mathf.Abs(animator.transform.localScale.x) * -1, animator.transform.localScale.y);
            // }
            // else
            // {
            //     animator.SetBool("Walk", false);
            // }
        }
    }
}
