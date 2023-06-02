using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    PlayerData playerData = new PlayerData();
    public float Health;
    public int Exp;
    private void Start()
    {
        Health = playerData.player_Health;
        Exp = playerData.player_Exp;
    }
}
