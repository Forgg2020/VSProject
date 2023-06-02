using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    public GameObject Player;
    PlayerData playerData = new PlayerData();
    PlayerBuff playerBuff;
    PlayerInteract playerInteract;
    PlayerState playerState;
    PlayerMovement playerMovement;
    
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerInteract = Player.GetComponent<PlayerInteract>();
        playerMovement = Player.GetComponent<PlayerMovement>();
        playerBuff = GetComponent<PlayerBuff>();
        
    }


    public float GetSSSSpeed() => playerBuff.Add_ExtraSpeed;
    

}
