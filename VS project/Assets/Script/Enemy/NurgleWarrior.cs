using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToolManager;
using UnityEditor;

public class NurgleWarrior : EnemyData
{
    protected override void Start()
    {
        base.Start();
        i = Random.Range(0, 2);
        j = Random.Range(0, 2);
        GetAssetData();
        GetBody();
        enemy_Health = 30;
        enemy_Speed = 3;
        enemy_AttackVaule = 10;
        EnemyBody = DeadBodyObj;
    }
    public void GetAssetData()
    {
        if (i == 0)
        {
            DeadBodyObj = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/CharactorPrefab/SpiltCharactor/Body-LR.prefab", typeof(GameObject));
            DeadBodysprite[0] = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/2D Aseet/Enemy/Splited/NurgleWarriors-Left.png", typeof(Sprite));
            DeadBodysprite[1] = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/2D Aseet/Enemy/Splited/NurgleWarriors-Right.png", typeof(Sprite));
        }
        else if (i == 1)
        {
            DeadBodyObj = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/CharactorPrefab/SpiltCharactor/Body-TD.prefab", typeof(GameObject));
            DeadBodysprite[0] = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/2D Aseet/Enemy/Splited/NurgleWarriors-Top.png", typeof(Sprite));
            DeadBodysprite[1] = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/2D Aseet/Enemy/Splited/NurgleWarriors-Down.png", typeof(Sprite));
        }
    }
    public void GetBody()
    {
        DeadBodyObj.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = DeadBodysprite[0];
        DeadBodyObj.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = DeadBodysprite[1];

    }
    public void GetSprite()
    {
        //GameObject BodySplit0 = DeadBodyObj.transform.GetChild(0).gameObject;
        //GameObject BodySplit1 = DeadBodyObj.transform.GetChild(1).gameObject;
        //SpriteRenderer SR01 = BodySplit0.GetComponent<SpriteRenderer>();
        //SpriteRenderer SR02 = BodySplit1.GetComponent<SpriteRenderer>();
        //SR01.sprite = sprite[0];
        //SR02.sprite = sprite[1];
    }
}
