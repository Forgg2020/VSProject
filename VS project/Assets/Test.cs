using System;
using System.Collections;
using System.Collections.Generic;
using ToolManager;
using UnityEngine;
using System.Linq;
using System.Reflection;

public class Test : MonoBehaviour
{
    private void Start()
    {
        //instance
    }
    
    void saveSave ()
    {
        bool isDerivedFromMonoBehaviour = typeof(Test).IsSubclassOf(typeof(MonoBehaviour));
        Debug.Log("YourScript is derived from MonoBehaviour: " + isDerivedFromMonoBehaviour);  // 输出结果：True

        bool isDerivedFromMonoBehaviour2 = typeof(ChainSword).IsSubclassOf(typeof(MonoBehaviour));
        Debug.Log("AnotherScript is derived from MonoBehaviour: " + isDerivedFromMonoBehaviour2);  // 输出结果：True
    }
}
