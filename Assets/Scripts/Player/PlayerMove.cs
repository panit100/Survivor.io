using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 10f;

    Vector2 direction;

    public Animator animator;
    public AudioSource audio;

    void Update()
    {
        GetDirection();
        Move();
        MoveAnimation();
        MoveSound();
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

    void MoveSound()
    {
        if(direction == Vector2.zero)
        {
            animator.SetBool("Walk", false);
            audio.Stop();
            return;
        }

        if(!audio.isPlaying)
            audio.Play();
    }

    void MoveAnimation()
    {
        if(direction.x > 0)
        {
            animator.SetBool("Walk", true);
            animator.transform.localScale = new Vector2(Mathf.Abs(animator.transform.localScale.x), animator.transform.localScale.y);
        }
        else if(direction.x < 0)
        {
            animator.SetBool("Walk", true);
            animator.transform.localScale = new Vector2(Mathf.Abs(animator.transform.localScale.x) * -1, animator.transform.localScale.y);
        }
        else
        {
            animator.SetBool("Walk", true);
        }
    }
}
