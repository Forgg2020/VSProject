using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToolManager;
using Completed;

public class EnemyInteract : MonoBehaviour
{
    EnemyDataManager enemyDataManager;
    public EnemyData enemydata;
    public EnemyState enemystate;
    public EnemyCalculate enemyCalculate;
    public delegate void OnDying();
    public event OnDying OnDead;
    public delegate void OnAttack(float atk);
    public event OnAttack OnAtk;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb2D;
    public Transform player;
    private void Start()
    {
        enemyDataManager = new EnemyDataManager();
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemydata = gameObject.GetComponent<EnemyData>();
        enemyCalculate = gameObject.GetComponent<EnemyCalculate>();
        enemystate = gameObject.GetComponent<EnemyState>();
        player = GameObject.FindWithTag("Player").transform;
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
            OnAtk?.Invoke(enemyDataManager.Enemy_Health);
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
        WeaponData weaponDataScript = colObj.gameObject.GetComponent<WeaponData>();
        //Enemy_Health() -= weaponDataScript.weapon_AttackDmg;
       enemydata.MinusHealth(weaponDataScript.weapon_AttackDmg);
        if(enemyDataManager.Enemy_Health <= 0)
        {
            OnDead?.Invoke();
            rb2D.simulated = false;
            Color color = spriteRenderer.color;
            color.a = 0;
            spriteRenderer.color = color;
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
        float playerPositionX = player.position.x;
        float enemyPositionX = gameObject.transform.position.x;

        if(enemystate.isDead == false) 
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