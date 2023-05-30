using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToolManager;
using Unity.VisualScripting;

public class EnemyState : MonoBehaviour
{
    FindObj findObj = new FindObj();
    EnemyInteract enemyInteract = new EnemyInteract();
    public void Start()
    {
        //gameObject.GetComponent<EnemyInteract>().OnGetAtk += GetHurt;
    }

    public void GetHurt()
    {
        //Debug.Log("ATK");
    }

    //public GameObject GetEnemy()
    //{
    //    for (int i = 0; i < 10; i++)
    //    {
    //        enemyInteract.InteractChar[i] = findObj.FindObjectbyTag("Enemy");
    //    }

    //    return enemyInteract.InteractChar[i];
    //}


}