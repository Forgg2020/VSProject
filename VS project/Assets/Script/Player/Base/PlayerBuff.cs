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
    LevelState levelManager;
    PlayerData playerData;
    public GameObject BuffPanel;

    public int KhroneValue;
    private void Start()
    {
        playerDataManager = gameObject.GetComponent<PlayerDataManager>();
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelState>();
    }
    public void PowerBuff()
    {
        if(KhroneValue < 4) 
        {
            Weapon_ExtraAtkValue = Weapon_ExtraAtkValue + 5;
            BuffPanel.SetActive(false);
            Time.timeScale = 1f;

        }
    }

    public void SpeedBuff()
    {
        player_ExtraSpeed = player_ExtraSpeed + 20;
        BuffPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void MoreDropRate()
    {
        BuffPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
