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
            if (enemyDataScript.enemy_Health >= 0)
            {
                enemyDataScript.enemy_Health -= Atkvalue;
            }
            Debug.Log("Found EnemyData script: " + enemyDataScript.GetType().Name);
        }
    }
}
