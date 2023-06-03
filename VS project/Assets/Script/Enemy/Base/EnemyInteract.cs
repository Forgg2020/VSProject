using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToolManager;
using Completed;

public class EnemyInteract : MonoBehaviour
{
    EnemyDataManager enemyDataManager;
    public EnemyData enemydata;

    public delegate void OnDying();
    public event OnDying OnDead;
    public delegate void OnAttack(float atk);
    public event OnAttack OnAtk;
    public delegate void OnHurt(GameObject whichweapon);
    public event OnHurt BeAtk;


    private void Start()
    {
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
        if (other.gameObject.CompareTag("Player"))
        {
            OnAtk?.Invoke(enemyDataManager.Enemy_Health());
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(AttackPlayerCoroutine());
        }
    }
    private void Geturt(GameObject colObj)
    {
        //WeaponData weaponDataScript = colObj.gameObject.GetComponent<WeaponData>();
        //Enemy_Health() -= weaponDataScript.weapon_AttackDmg;
        BeAtk?.Invoke(colObj);
        //EnemyCalculate.MinusHealth(weaponDataScript.weapon_AttackDmg);
        if(enemyDataManager.Enemy_Health() <= 0)
        {
            OnDead?.Invoke();
            enemyDataManager.Enenmy_Rb2D().simulated = false;
            Color color = enemyDataManager.Enemy_SpirtRenderer().color;
            color.a = 0;
            enemyDataManager.Enemy_SpirtRenderer().color = color;
        }
    }
    private IEnumerator AttackPlayerCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            OnAtk?.Invoke(enemydata.enemy_AttackVaule);
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