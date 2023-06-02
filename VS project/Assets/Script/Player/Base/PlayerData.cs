using System.Collections;
using System.Collections.Generic;
using ToolManager;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData
{
    InputSystem inputSystem;
    FindObj findObj;
    //****************************基礎數值****************************//
    public virtual int player_Level { get; set; } = 0;
    public virtual int player_Exp { get; set; } = 0;
    public virtual int player_WeaponBox { get; set; } = 1;
    public virtual int player_Shield { get; set; } = 2;
    public virtual float player_Health { get; set; } = 50f;
    public virtual float player_Speed { get; set; } = 24f;
    public virtual float player_DashSpeed { get; set; } = 48f;
    public virtual float player_InvincibleTime { get; set;} = 0.5f;
    public virtual float player_AttackValue { get; set; } = 10;

    public Transform PlyaerTran;
    //****************************UI****************************//
    //****************************Dash衝刺****************************//
    public float dashingCooldown = 1f;
    public float dashPower = 24.0f;
    public float dashTime = 0.2f;
    public bool canDash = true;
    public bool isDashing;

    void Start()
    {
        
    }
    void Update()
    {
    }
}
