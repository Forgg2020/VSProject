using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToolManager;

public class EnemyInteract : MonoBehaviour
{    
    public delegate void OnGetAttack(float Atk);
    public event OnGetAttack OnGetAtk;
    public List<GameObject> InteractChar = new List<GameObject>();

    private void Start()
    {
        EnemyData[] enemyDataScripts = GetComponents<EnemyData>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            WeaponData weaponDataScript = other.gameObject.GetComponent<WeaponData>();
            print(weaponDataScript.weapon_AttackDmg);
            OnGetAtk?.Invoke(weaponDataScript.weapon_AttackDmg);
        }
    }
}
