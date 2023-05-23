using System.Collections;
using System.Collections.Generic;
using ToolManager;
using UnityEngine;
using System.Linq;


public class WeaponManager : MonoBehaviour
{
    public List<GameObject> listName = new List<GameObject>();
    FindObj FindObj = new FindObj();

    void Start()
    {
        //listName.Add(FindObj.FindObjectbyTag("Weapon"));
    }

    void AttackInCD()
    {
        
    }
}
