using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using ToolManager;

public class ChaosWarrior : EnemyData
{
    protected override void Start()
    {
        base.Start();
        WhichSpiltBody = Random.Range(0, 2);
        WhichAnim = Random.Range(0, 2);

        GetAssetData();
        GetBody();
        enemy_Health = 20;
        enemy_Speed = 5;
        enemy_AttackVaule = 10;

        //GetSprite(i, DeadBodyObj, sprite[0], sprite[1]);
    }
    public void GetAssetData()
    {
        if (WhichSpiltBody == 0)
        {
            DeadBodyObj = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/CharactorPrefab/SpiltCharactor/Body-LR.prefab", typeof(GameObject));
            DeadBodysprite[0] = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/2D Aseet/Enemy/Splited/ChaosWarriors-Left.png", typeof(Sprite));
            DeadBodysprite[1] = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/2D Aseet/Enemy/Splited/ChaosWarriors-Right.png", typeof(Sprite));
        }
        else if (WhichSpiltBody == 1)
        {
            DeadBodyObj = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/CharactorPrefab/SpiltCharactor/Body-TD.prefab", typeof(GameObject));
            DeadBodysprite[0] = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/2D Aseet/Enemy/Splited/ChaosWarriors-Top.png", typeof(Sprite));
            DeadBodysprite[1] = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/2D Aseet/Enemy/Splited/ChaosWarriors-Down.png", typeof(Sprite));
        }
    }
    public void GetBody()
    {
        DeadBodyObj.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = DeadBodysprite[0];
        DeadBodyObj.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = DeadBodysprite[1];
        EnemyBody = DeadBodyObj;
    }
}
