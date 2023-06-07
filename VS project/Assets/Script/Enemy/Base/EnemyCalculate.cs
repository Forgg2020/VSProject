using System.Collections;
using System.Collections.Generic;
using ToolManager;
using UnityEditor;
using UnityEngine;

public class EnemyCalculate : MonoBehaviour
{
    EnemyDataManager enemyDataManager;
    EnemyData enemyData;
    public int whichBody;
    GameObject whcihweapon;
    public float timer = 0;
    public bool AtkFreq = false;
    PlayerBuff playerBuff;
    private void Start()
    {
        whichBody = Random.Range(0, 2);
        enemyData = gameObject.GetComponent<EnemyData>();
        enemyDataManager = gameObject.GetComponent<EnemyDataManager>();
        gameObject.GetComponent<EnemyInteract>().BeAtk += Geturt;
        playerBuff = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBuff>();
    }
    private void Update()
    {

    }
    private void Geturt(GameObject colObj)
    {
        float health = enemyDataManager.Enemy_Health();
        WeaponData weaponDataScript = colObj.gameObject.GetComponent<WeaponData>();
        enemyData.enemy_Health -= (weaponDataScript.weapon_AttackDmg + playerBuff.Weapon_ExtraAtkValue);

        print("ATK:" + weaponDataScript.weapon_AttackDmg + playerBuff.Weapon_ExtraAtkValue);
        //EnemyCalculate.MinusHealth(weaponDataScript.weapon_AttackDmg);
    }
}
