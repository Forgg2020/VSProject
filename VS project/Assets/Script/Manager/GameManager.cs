using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToolManager;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    FindObj findObj = new FindObj();
    public static GameManager instance;
    public static GameObject Player;
    private void Awake()
    {
        Player = GameObject.Find("Player");
        //if (Player = null)
        //{
        //    findObj.FindObjectbyTag("Player");
        //    print(Player.tag);
        //}
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // 其他Awake方法的逻辑
    }
    public void Start()
    {
        
    }
    private GameManager()
    {
        // 初始化GameManager的逻辑
    }
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameManager();
            }
            return instance;
        }
    }
    
}
