using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDataManager : MonoBehaviour
{
    WeaponData weaponData;
    PlayerBuff playerBuff;
    private void Start()
    {
        weaponData = gameObject.GetComponent<WeaponData>();
        playerBuff = GameObject.Find("Player").GetComponent<PlayerBuff>();
    }

    public float ExtraAtkValue() => playerBuff.Weapon_ExtraAtkValue;
}
