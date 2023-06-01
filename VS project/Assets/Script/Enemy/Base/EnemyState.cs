using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToolManager;
using Unity.VisualScripting;
using System.Net.NetworkInformation;

public class EnemyState : MonoBehaviour
{
    FindObj findObj = new FindObj();

   
    public void Start()
    {
        //gameObject.GetComponent<EnemyInteract>().OnDying += Dying;
    }


    //public void Dying(float atk)
    //{
        
    //    StartCoroutine(FadeOutCoroutine());
    //}

}