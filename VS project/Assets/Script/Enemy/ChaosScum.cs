using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using ToolManager;

public class ChaosScum : EnemyData
{
    public int i;
    public GameObject DeadBodyObj;
    public Sprite[] sprite;
    protected override void Start()
    {
        base.Start();

        i = Random.Range(0, 2);
        GetAssetData();
        GetSprite(i, DeadBodyObj, sprite[0], sprite[1]);
        Initialize(10, 5, 1, DeadBodyObj);
    }
    public void GetAssetData()
    {
        int j = Random.Range(0, 2);
        if (i == 0)
        {
            DeadBodyObj = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/CharactorPrefab/SpiltCharactor/Body-LR.prefab", typeof(GameObject));
            sprite[0] = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/2D Aseet/Enemy/Splited/Chaos scum-Left.png", typeof(Sprite));
            sprite[1] = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/2D Aseet/Enemy/Splited/Chaos scum-Right.png", typeof(Sprite));
        }
        else if (i == 1) 
        {
            DeadBodyObj = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/CharactorPrefab/SpiltCharactor/Body-TD.prefab", typeof(GameObject));
            sprite[0] = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/2D Aseet/Enemy/Splited/Chaos scum-Top.png", typeof(Sprite));
            sprite[1] = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/2D Aseet/Enemy/Splited/Chaos scum-Down.png", typeof(Sprite));
        }
    }
}

