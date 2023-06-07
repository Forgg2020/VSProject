using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelData : MonoBehaviour
{
    [Header("UI")]
    public GameObject UpPanel;
    public GameObject EndPanel;
    public Image bloodbar;

    public void Start()
    {
        UpPanel = GameObject.Find("UPPanel");
        EndPanel = GameObject.Find("EndPanel");
    }
}
