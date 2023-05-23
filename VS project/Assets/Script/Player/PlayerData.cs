using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerData
{
    //****************************基礎數值****************************//
    public virtual int player_Level { get; } = 0;
    public virtual int player_Exp { get; } = 0;
    public virtual int player_WeaponBox { get; } = 1;
    public virtual int player_Shield { get; } = 2;
    public virtual float player_Health { get; } = 50f;
    public virtual float player_Speed { get; set; } = 24f;
    public virtual float player_DashSpeed { get; } = 48f;
    public virtual float player_InvincibleTime { get; } = 0.5f;

    //****************************Dash衝刺****************************//
    public float dashingCooldown = 1f;
    public float dashPower = 24.0f;
    public float dashTime = 0.2f;
    public bool canDash = true;
    public bool isDashing;
}
