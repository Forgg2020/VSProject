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
        Initialize(10, 5, 1);
    }
}