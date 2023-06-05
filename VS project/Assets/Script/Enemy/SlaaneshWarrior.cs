using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using ToolManager;

public class SlaaneshWarrior : EnemyData
{
    protected override void Start()
    {
        base.Start();
        i = Random.Range(0, 2);
        j = Random.Range(0, 2);
        GetAssetData();
        GetBody();
        enemy_Health = 20;
        enemy_Speed = 7;
        enemy_AttackVaule = 10;
        EnemyBody = DeadBodyObj;
    }
    public void GetAssetData()
    {
        if (i == 0)
        {
            DeadBodyObj = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/CharactorPrefab/SpiltCharactor/Body-LR.prefab", typeof(GameObject));
            DeadBodysprite[0] = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/2D Aseet/Enemy/Splited/SlaaneshWarriors-Left.png", typeof(Sprite));
            DeadBodysprite[1] = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/2D Aseet/Enemy/Splited/SlaaneshWarriors-Right.png", typeof(Sprite));
        }
        else if (i == 1)
        {
            DeadBodyObj = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/CharactorPrefab/SpiltCharactor/Body-TD.prefab", typeof(GameObject));
            DeadBodysprite[0] = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/2D Aseet/Enemy/Splited/SlaaneshWarriors-Top.png", typeof(Sprite));
            DeadBodysprite[1] = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/2D Aseet/Enemy/Splited/SlaaneshWarriors-Down.png", typeof(Sprite));
        }
    }
    public void GetBody()
    {
        DeadBodyObj.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = DeadBodysprite[0];
        DeadBodyObj.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = DeadBodysprite[1];
    }
}