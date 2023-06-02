using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToolManager;

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

    private void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemydata = gameObject.GetComponent<EnemyData>();
        enemyCalculate = gameObject.GetComponent<EnemyCalculate>();
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
}