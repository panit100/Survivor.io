using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 10f;

    Vector3 direction;

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
        if(direction == Vector3.zero)
        {
            animator.Play("Idle");
            audio.Stop();
            return;
        }

        if(!audio.isPlaying)
            audio.Play();
    }

    void MoveAnimation()
    {
        if(direction.x > 0)
            animator.Play("WalkRight");
        else if(direction.x < 0)
            animator.Play("WalkLeft");
        else
            animator.Play("WalkDown");
    }
}
