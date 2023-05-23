using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ChainSword : WeaponData
{
    Animator Am;
    public new float weapon_AttackFreq = 5f;

    public delegate void OnWeaponCD();
    public event OnWeaponCD OnTurnHorizontal;
    void Start()
    {        
        Am = GetComponent<Animator>();
        Am.SetBool("Atk", true);
    }

    // Update is called once per frame
    void Update()
    {
        weapon_AttackFreq -= Time.deltaTime;
        if(weapon_AttackFreq < 0) 
        { }
    }

}
