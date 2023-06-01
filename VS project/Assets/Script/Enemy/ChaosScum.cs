using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToolManager;

public class ChaosScum : EnemyData
{
    FindObj FindObj = new FindObj();
    public GameObject DeadBody;
    protected override void Start()
    {
        base.Start();
        Initialize(10, 5, 1, DeadBody);
    }

}
