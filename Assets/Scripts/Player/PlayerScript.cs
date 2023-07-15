using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TA
{
public class PlayerScript : MonoBehaviour
{
    PlayerMove playerMove;
    PlayerHealth playerHealth;
    PlayerLevel playerLevel;

    public PlayerMove PlayerMove {get{ return playerMove;}}
    public PlayerHealth PlayerHealth {get{ return playerHealth;}}
    public PlayerLevel PlayerLevel {get{ return playerLevel;}}

    void Start()
    {
        playerMove = GetComponent<PlayerMove>();
        playerHealth = GetComponent<PlayerHealth>();
        playerLevel = GetComponent<PlayerLevel>();
    }
}
}

