using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using ToolManager;

public class ChaosWarrior : EnemyData
{
    public int i;
    public int j;
    public GameObject DeadBodyObj;
    public Sprite[] sprite;
    protected override void Start()
    {
        base.Start();
        i = Random.Range(0, 2);
        j = Random.Range(0, 2);
        GetAssetData();
        GetSprite(i, DeadBodyObj, sprite[0], sprite[1]);
        Initialize(10, 5, 1, DeadBodyObj);
        enemy_Health = 20;
        enemy_Speed = 5;
        enemy_AttackVaule = 10;
    }
    public void GetAssetData()
    {
        if (i == 0)
        {
            DeadBodyObj = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/CharactorPrefab/SpiltCharactor/Body-LR.prefab", typeof(GameObject));
            sprite[0] = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/2D Aseet/Enemy/Splited/ChaosWarriors-Left.png", typeof(Sprite));
            sprite[1] = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/2D Aseet/Enemy/Splited/ChaosWarriors-Right.png", typeof(Sprite));
        }
        else if (i == 1)
        {
            DeadBodyObj = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/CharactorPrefab/SpiltCharactor/Body-TD.prefab", typeof(GameObject));
            sprite[0] = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/2D Aseet/Enemy/Splited/ChaosWarriors-Top.png", typeof(Sprite));
            sprite[1] = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/2D Aseet/Enemy/Splited/ChaosWarriors-Down.png", typeof(Sprite));
        }
    }
}
