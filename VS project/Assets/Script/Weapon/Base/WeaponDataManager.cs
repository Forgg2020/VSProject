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
        playerBuff = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBuff>();
        playerDataManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDataManager>();
    }

    public float ExtraAtkValue() => playerBuff.Weapon_ExtraAtkValue;
    public Transform PlayerTransform() => playerDataManager.Player_Transform;
}
