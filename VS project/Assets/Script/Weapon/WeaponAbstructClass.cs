using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAbstructClass : MonoBehaviour 
{
    //****************************攻擊數值****************************//
    [field : SerializeField]public virtual float weapon_AttackFreq { get; set; }
    [field: SerializeField]public virtual float weapon_AttackCD { get; set; }
    [field: SerializeField]public virtual float weapon_AttackDmg { get; set; }
    [field: SerializeField]public virtual float weapon_AttackRange { get; set; }
    [field: SerializeField]public virtual float weapon_AttackRepel { get; set; }
    [field: SerializeField]public virtual Animator weapon_Animator { get; set; }
    public virtual void GetAnim()
    {
        weapon_Animator = GetComponent<Animator>();
    }
}
