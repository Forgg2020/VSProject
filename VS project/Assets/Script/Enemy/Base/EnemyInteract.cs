using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToolManager;

public class EnemyInteract : MonoBehaviour
{    
    public delegate void OnGetAttack(float Atk);
    public event OnGetAttack OnGetAtk;
    public event OnGetAttack OnDying;
    public List<GameObject> InteractChar = new List<GameObject>();

    private void Start()
    {
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            WeaponData weaponDataScript = other.gameObject.GetComponent<WeaponData>();

            EnemyData[] enemyDataScripts = GetComponents<EnemyData>();
            foreach (EnemyData enemyDataScript in enemyDataScripts)
            {
                if (enemyDataScript.enemy_Health > 0)
                {
                    OnGetAtk?.Invoke(weaponDataScript.weapon_AttackDmg);
                }
                else if (enemyDataScript.enemy_Health <= weaponDataScript.weapon_AttackDmg)
                {
                    OnDying?.Invoke(weaponDataScript.weapon_AttackDmg);
                }
            }
        }

    }


}
