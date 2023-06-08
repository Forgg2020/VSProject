using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    PlayerData playerData = new PlayerData();
    PlayerBuff playerBuff;
    PlayerInteract playerInteract;
    PlayerState playerState;
    PlayerMovement playerMovement;
    InputSystem inputsystem;
    
    private void Start()
    {
        playerInteract = gameObject.GetComponent<PlayerInteract>();
        playerMovement = gameObject.GetComponent<PlayerMovement>();
        playerBuff = gameObject.GetComponent<PlayerBuff>();
        inputsystem = gameObject.GetComponent<InputSystem>();
    }

    public Transform Player_Transform => playerMovement.PlayerTransform;
    public Rigidbody2D Player_Rb2D() => gameObject.GetComponent<Rigidbody2D>();
    public float Player_Speed() => playerData.player_Speed + playerBuff.player_ExtraSpeed;

}
