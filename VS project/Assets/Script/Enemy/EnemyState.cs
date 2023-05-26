using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToolManager;

public class EnemyState : MonoBehaviour
{
    FindObj findObj = new FindObj();
    public void Start()
    {
        GetEnemy().GetComponent<EnemyM>().OnGetAtk += GetHurt;
    } 

    public void GetHurt()
    {
        Debug.Log("ATK");
    }

    public GameObject GetEnemy()
    {
        GameObject PlayerEnemy = findObj.FindObjectbyTag("Enemy");
        return PlayerEnemy;
    }
}
