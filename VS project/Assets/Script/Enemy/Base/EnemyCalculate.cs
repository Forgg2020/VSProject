using System.Collections;
using System.Collections.Generic;
using ToolManager;
using UnityEditor;
using UnityEngine;

public class EnemyCalculate : MonoBehaviour
{
    EnemyData enemyData;
    [Header("Žr?")]
    public int whichBody;
    
    private void Start()
    {
        enemyData = GetComponent<EnemyData>();
        whichBody = Random.Range(0, 2);
        
    }

    public void MinusHealth(float i)
    {
        
    }

    public void HowToDie(int i ,GameObject Body)
    {
       
    }
}
