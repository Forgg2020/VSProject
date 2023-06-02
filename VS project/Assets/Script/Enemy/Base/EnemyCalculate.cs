using System.Collections;
using System.Collections.Generic;
using ToolManager;
using UnityEditor;
using UnityEngine;

public class EnemyCalculate : MonoBehaviour
{
    [Header("屍?")]
    public int whichBody;
    
    private void Start()
    {
        whichBody = Random.Range(0, 2);
        
    }
}
