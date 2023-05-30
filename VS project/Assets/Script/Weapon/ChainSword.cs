using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ChainSword : WeaponData
{
    private void Start()
    {
        weapon_AttackFreq = 2;
        weapon_AttackCD = 2;
        weapon_AttackDmg = 10f;
        weapon_AttackRange = 10;
        weapon_AttackRepel = 10;
    }    
}
