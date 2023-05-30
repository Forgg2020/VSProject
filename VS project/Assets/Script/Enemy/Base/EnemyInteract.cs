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
        WeaponData weaponDataScript = GetComponent<WeaponData>();
        if (other.gameObject.CompareTag("Weapon"))
        {
            
            OnGetAtk?.Invoke(weaponDataScript.weapon_AttackDmg);
        }
    }
    private void Update()
    {
    }
}
