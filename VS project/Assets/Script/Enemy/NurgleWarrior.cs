using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToolManager;

public class NurgleWarrior : EnemyData
{
    FindObj FindObj = new FindObj();
    protected override void Start()
    {
        base .Start();
        enemy_Health = 20;
        enemy_Speed = 5;
        enemy_AttackVaule = 1;

    }
}
