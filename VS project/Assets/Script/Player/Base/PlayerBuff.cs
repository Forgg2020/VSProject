using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToolManager;
using static UnityEditor.Handles;

public class PlayerBuff : MonoBehaviour
{
    public int player_ExtraSpeed = 0;
    public int player_ExtraHeal = 5;
    public float Weapon_ExtraAtkValue;
    public int Item_DropRate;
    public GameObject BuffPanel;
    TimeFunction timeFunction = new TimeFunction();
    public int KhroneValue;
    
    public void PowerBuff()
    {
        if(KhroneValue < 4) 
        {
            Weapon_ExtraAtkValue = Weapon_ExtraAtkValue + 5;
            BuffPanel.SetActive(false);
            timeFunction.KeepTime();
        }
    }

    public void SpeedBuff()
    {
        player_ExtraSpeed = player_ExtraSpeed + 20;
        BuffPanel.SetActive(false);
        timeFunction.KeepTime();
    }

    public void MoreDropRate()
    {
        BuffPanel.SetActive(false);
        timeFunction.KeepTime();
    }
}
