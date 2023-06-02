using System.Collections;
using System.Collections.Generic;
using ToolManager;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    FindObj FindObj = new FindObj();
    public Image bloodbar;
    public List<GameObject> EnemyPool;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerGetHurt(float atkvalue)
    {
        var Atk_percentage = atkvalue / 100;
        bloodbar.fillAmount -= Atk_percentage;
        print(Atk_percentage);

    }
    public void AddEnemyToPool(GameObject enemy)
    {        
        EnemyPool.Add(enemy);
        EnemyInteract enemyInteract = enemy.GetComponent<EnemyInteract>();
        if (enemyInteract != null)
        {
            enemyInteract.OnAtk += PlayerGetHurt;
        }

    }

}
