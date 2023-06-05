using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToolManager;
using UnityEditor;

public class TzeentchWarrior : EnemyData
{
    protected override void Start()
    {
        base.Start();
        i = Random.Range(0, 2);
        j = Random.Range(0, 2);
        GetAssetData();
        GetBody();
        enemy_Health = 20;
        enemy_Speed = 5;
        enemy_AttackVaule = 20;
        EnemyBody = DeadBodyObj;
    }
    public void GetAssetData()
    {
        if (i == 0)
        {
            DeadBodyObj = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/CharactorPrefab/SpiltCharactor/Body-LR.prefab", typeof(GameObject));
            DeadBodysprite[0] = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/2D Aseet/Enemy/Splited/Chaos scum-Left.png", typeof(Sprite));
            DeadBodysprite[1] = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/2D Aseet/Enemy/Splited/Chaos scum-Right.png", typeof(Sprite));
        }
        else if (i == 1)
        {
            DeadBodyObj = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/CharactorPrefab/SpiltCharactor/Body-TD.prefab", typeof(GameObject));
            DeadBodysprite[0] = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/2D Aseet/Enemy/Splited/Chaos scum-Top.png", typeof(Sprite));
            DeadBodysprite[1] = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/2D Aseet/Enemy/Splited/Chaos scum-Down.png", typeof(Sprite));
        }
    }
    public void GetBody()
    {
        transform.GetChild(0).transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = DeadBodysprite[0];
        transform.GetChild(0).transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = DeadBodysprite[1];
    }
}



