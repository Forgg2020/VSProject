using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using ToolManager;

public class SlaaneshWarrior : EnemyData
{
    public int i;
    public GameObject DeadBodyObj;
    public Sprite[] sprite;
    protected override void Start()
    {
        base.Start();
        i = enemyCalculate.whichBody;
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
            sprite[0] = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/2D Aseet/Enemy/Splited/SlaaneshWarriors-Left.png", typeof(Sprite));
            sprite[1] = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/2D Aseet/Enemy/Splited/SlaaneshWarriors-Right.png", typeof(Sprite));
            Anim.SetInteger("Which", j);
        }
        else if (i == 1)
        {
            DeadBodyObj = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/CharactorPrefab/SpiltCharactor/Body-TD.prefab", typeof(GameObject));
            sprite[0] = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/2D Aseet/Enemy/Splited/SlaaneshWarriors-Top.png", typeof(Sprite));
            sprite[1] = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/2D Aseet/Enemy/Splited/SlaaneshWarriors-Down.png", typeof(Sprite));
            Anim.SetInteger("Which", j);
        }
    }
}