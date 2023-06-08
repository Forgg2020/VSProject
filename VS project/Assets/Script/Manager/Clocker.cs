using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clocker : MonoBehaviour
{
    LevelDataManager levelDataManager;
    public Animator Anim;
    public Sprite[] timerSprite;
    public Image N1;
    public Image N2;
    public float Digits;
    public float Ten;


    private void Start()
    {
        levelDataManager = gameObject.GetComponent<LevelDataManager>();
    }
    public void Update()
    {
        Anim.SetFloat("Timer", levelDataManager.LevelTimer());
        Ten = levelDataManager.LevelTimer() / 10;
        int i = Mathf.FloorToInt(Ten);
        N1.sprite = timerSprite[i];
        Digits = levelDataManager.LevelTimer() % 10;
        int j = Mathf.FloorToInt(Digits);
        N2.sprite = timerSprite[j];
    }
}
