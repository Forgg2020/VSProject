using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToolManager;

public class EnemyInteract : MonoBehaviour
{
    public EnemyData enemydata;
    public EnemyCalculate enemyCalculate;
    public delegate void OnGetAttack(float Atk);
    public event OnGetAttack OnGetAtk;
    public event OnGetAttack OnDying;
    Rigidbody2D rb2D;

    private void Start()
    {
        enemydata = gameObject.GetComponent<EnemyData>();
        enemyCalculate = gameObject.GetComponent<EnemyCalculate>();
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            Geturt(other.gameObject);
        }
    }
    private void Geturt(GameObject colObj)
    {
        WeaponData weaponDataScript = colObj.gameObject.GetComponent<WeaponData>();
        enemydata.MinusHealth(weaponDataScript.weapon_AttackDmg);
        if(enemydata.enemy_Health <= 0)
        {
            rb2D.simulated = false;
            StartCoroutine(enemyCalculate.FadeOutCoroutine());
        }
    }
}