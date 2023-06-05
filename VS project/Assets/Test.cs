using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Sprite[] Sp;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject enemyspilt = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/CharactorPrefab/SpiltCharactor/Body-LR.prefab", typeof(GameObject));
        
        enemyspilt.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/2D Aseet/Enemy/Splited/Chaosscum-Left.png", typeof(Sprite));
        enemyspilt.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/2D Aseet/Enemy/Splited/Chaosscum-Right.png", typeof(Sprite));
        Instantiate(enemyspilt);
    }
}
