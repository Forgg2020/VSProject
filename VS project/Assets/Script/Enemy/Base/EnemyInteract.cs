using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToolManager;
using Completed;

public class EnemyInteract : MonoBehaviour
{
    EnemyDataManager enemyDataManager;
    LevelManager levelManager;
    public EnemyData enemydata;

    public delegate void OnDying();
    public event OnDying OnDead;
    public delegate void OnAttack(float atk);
    public event OnAttack OnAtk;
    public delegate void OnHurt(GameObject whichweapon);
    public event OnHurt BeAtk;

    public bool canEtk = true;


    private void Start()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();    
        enemyDataManager = gameObject.GetComponent<EnemyDataManager>();
        enemydata = gameObject.GetComponent<EnemyData>();
    }

    private void Update()
    {
        Fliping();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            Geturt(other.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(canEtk == true)
            {
                canEtk = false; 
                OnAtk?.Invoke(enemyDataManager.Enemy_AttackValue());
                StartCoroutine(AttackPlayerCoroutine());
            }
        }
    }
    private IEnumerator AttackPlayerCoroutine()
    {
        yield return new WaitForSeconds(2f);
        canEtk = true;
    }
    private void Geturt(GameObject colObj)
    {        
        BeAtk?.Invoke(colObj);
        if(enemyDataManager.Enemy_Health() <= 0)
        {
            OnDead?.Invoke();
            enemyDataManager.Enenmy_Rb2D().simulated = false;
            Color color = enemyDataManager.Enemy_SpirtRenderer().color;
            color.a = 0;
            enemyDataManager.Enemy_SpirtRenderer().color = color;
            levelManager.RemoveEnemyToPool(gameObject);
        }
    }
    public void Fliping()
    {
        float playerPositionX = enemyDataManager.GetPlayer().transform.position.x;
        float enemyPositionX = gameObject.transform.position.x;

        if(enemyDataManager.Enemy_DeadorNot() == false) 
        {
            if (playerPositionX < enemyPositionX)
            {
                gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            }
            else
            {
                gameObject.transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
            }
        }        
    }
}