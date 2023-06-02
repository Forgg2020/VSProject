using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToolManager;
using Completed;

public class EnemyInteract : MonoBehaviour
{
    public EnemyData enemydata;
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
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemydata = gameObject.GetComponent<EnemyData>();
        enemyCalculate = gameObject.GetComponent<EnemyCalculate>();
        player = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        float playerPositionX = player.position.x;
        float enemyPositionX = gameObject.transform.position.x;

        // 判断玩家在敌人的左边还是右边，并根据情况调整敌人的朝向
        if (playerPositionX < enemyPositionX)
        {
            // 玩家在敌人的左边，敌人朝向左边
            gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else
        {
            // 玩家在敌人的右边，敌人朝向右边
            gameObject.transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            Geturt(other.gameObject);
        }
        if (other.gameObject.CompareTag("Player"))
        {
            OnAtk?.Invoke(enemydata.enemy_AttackVaule);
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
        enemydata.MinusHealth(weaponDataScript.weapon_AttackDmg);
        if(enemydata.enemy_Health <= 0)
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


}