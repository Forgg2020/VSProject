using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelDataManager : MonoBehaviour
{
    LevelData levelData;
    LevelState levelstate;

    private void Start()
    {
        levelData = gameObject.GetComponent<LevelData>();
        levelstate= gameObject.GetComponent<LevelState>();
    }
    public GameObject UpPanel() => levelData.UpPanel;
    public GameObject EndPanel() => levelData.EndPanel;
    public Image Player_BloodBar() => levelData.bloodbar;
    public float LevelTimer() => levelstate.timer;
    public GameObject Player() => levelData.Plyaer;
}
