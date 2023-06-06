using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class LazerGun : WeaponData
{
    public GameObject BulletPrefab;
    public GameObject BulletObj;
    public new void Start()
    {
        weapon_AttackFreq = 2;
        weapon_AttackCD = 2;
        weapon_AttackDmg = 10f;
        weapon_AttackRange = 10;
        weapon_AttackRepel = 10;
    }

    public void Shooting()
    {
        Instantiate(BulletPrefab, BulletObj.transform.position, BulletObj.transform.rotation, null);
    }
}
