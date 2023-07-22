using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TA
{
    public class PlayerMoveSound : MonoBehaviour
    {
        PlayerMove playerMove;
        public AudioSource audio;

        void Start()
        {
            playerMove = GetComponent<PlayerMove>();
        }

        void Update()
        {
            MoveSound();
        }

        void MoveSound()
        {
            //Uncomment when PlayerMove.cs Finish
            
            // if(playerMove.direction == Vector2.zero)
            // {
            //     audio.Stop();
            //     return;
            // }

            // if(!audio.isPlaying)
            //     audio.Play();
        }
    }
}
