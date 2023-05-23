using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponData : MonoBehaviour 
{
    //****************************攻擊數值****************************//
    public virtual float weapon_AttackFreq { get; set; }
    public virtual float weapon_AttackCD { get; }
    public virtual float weapon_AttackDmg { get; }
    public virtual float weapon_AttackRange { get; }
    public virtual float weapon_AttackRepel { get; }
    public virtual Animator weapon_Animator { get; set; }
    public virtual void GetAnim()
    {
        weapon_Animator = GetComponent<Animator>();
    }


}
