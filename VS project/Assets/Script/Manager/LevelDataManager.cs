using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelDataManager : MonoBehaviour
{
    LevelData levelData;
    
    private void Start()
    {
        levelData = gameObject.GetComponent<LevelData>();
    }
    public GameObject UpPanel => levelData.UpPanel;
    public GameObject EndPanel => levelData.EndPanel;
    public Image Player_BloodBar => levelData.bloodbar;
}
