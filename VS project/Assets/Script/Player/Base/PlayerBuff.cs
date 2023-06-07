using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuff : MonoBehaviour
{
    public int player_ExtraSpeed = 0;
    public int player_ExtraHeal = 5;
    public float Weapon_ExtraAtkValue;
    public int Item_DropRate;
    PlayerDataManager playerDataManager;
    PlayerData playerData;
    public GameObject BuffPanel;
    private void Start()
    {
        playerDataManager = gameObject.GetComponent<PlayerDataManager>();
    }
    public void PowerBuff()
    {
        Weapon_ExtraAtkValue = Weapon_ExtraAtkValue + 5;
        BuffPanel.SetActive(false);
    }

    public void SpeedBuff()
    {
        player_ExtraSpeed = player_ExtraSpeed + 20;
        BuffPanel.SetActive(false);
    }
}
