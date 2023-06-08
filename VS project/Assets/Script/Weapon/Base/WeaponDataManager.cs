using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDataManager : MonoBehaviour
{
    WeaponData weaponData;
    PlayerBuff playerBuff;
    PlayerDataManager playerDataManager;    
    private void Start()
    {
        weaponData = gameObject.GetComponent<WeaponData>();
        playerBuff = GameObject.Find("Player").GetComponent<PlayerBuff>();
        playerDataManager = GameObject.Find("Player").GetComponent<PlayerDataManager>();
    }

    public float ExtraAtkValue() => playerBuff.Weapon_ExtraAtkValue;
    public Transform PlayerTransform() => playerDataManager.Player_Transform;
}
