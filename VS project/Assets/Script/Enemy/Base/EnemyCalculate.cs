using System.Collections;
using System.Collections.Generic;
using ToolManager;
using UnityEditor;
using UnityEngine;

public class EnemyCalculate : MonoBehaviour
{
    public int whichBody;
    
    private void Start()
    {
        whichBody = Random.Range(0, 2);        
    }
}
