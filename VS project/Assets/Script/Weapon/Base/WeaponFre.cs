using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToolManager;

public class WeaponFre : WeaponAbstructClass
{
    private void Start()
    {
        GetAnim();
    }

    public void Update()
    {
        //print(weapon_Animator);
    }
    public override void GetAnim()
    {
        weapon_Animator = GetComponent<Animator>();
    }

}

