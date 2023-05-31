using System.Collections;
using System.Collections.Generic;
using ToolManager;

public class KhorneWarrior : EnemyData
{
    FindObj FindObj = new FindObj();
    protected override void Start()
    {
        base.Start();
        Initialize(10, 5, 1);
    }
}
