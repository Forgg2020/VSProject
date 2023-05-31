using System.Collections;
using System.Collections.Generic;
using ToolManager;
using UnityEngine;

public class EnemyCalculate : MonoBehaviour
{
    
    public void Start()
    {
       gameObject.GetComponent<EnemyInteract>().OnGetAtk += GetHurt;
    }

    public void GetHurt(float Atkvalue)
    {
        EnemyData[] enemyDataScripts = GetComponents<EnemyData>();
        foreach (EnemyData enemyDataScript in enemyDataScripts)
        {
            enemyDataScript.enemy_Health -= Atkvalue;            
        }
    }
}
