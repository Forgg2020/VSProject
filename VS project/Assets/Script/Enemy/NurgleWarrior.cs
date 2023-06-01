using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToolManager;
using System;

public class NurgleWarrior : EnemyData
{
    FindObj FindObj = new FindObj();
    public GameObject DeadBody;
    protected override void Start()
    {
        base.Start();
        Initialize(10, 5, 1, DeadBody);
        int i = UnityEngine.Random.Range(0, 2);
        if(i == 0)
        {
            GameObject BodyObject = Resources.Load<GameObject>("Body-LR");
            if(BodyObject != null)
            {
                BodyObject = DeadBody;
            }
            else
            {
                Debug.LogError("Failed to load 'Body-LR' object from resources.");
            }
        }
        else if(i == 1) 
        {
            GameObject BodyObject = Resources.Load<GameObject>("Body-TD");
            if (BodyObject != null)
            {
                BodyObject = DeadBody;
            }
            else
            {
                Debug.LogError("Failed to load 'Body-TD' object from resources.");
            }
        }
    }
}
