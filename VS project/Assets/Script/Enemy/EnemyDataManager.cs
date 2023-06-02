using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDataManager : MonoBehaviour
{
    public EnemyData enemyData;
    public EnemyState enemyState;
    public EnemyInteract enemyInteract;
    public EnemyCalculate enemyCalculate;
    public EnemyBodyAnimController enemyCalculateController;
    private void Start()
    {
        enemyData = gameObject.GetComponent<EnemyData>();
        enemyState = gameObject.GetComponent<EnemyState>();
        enemyInteract = gameObject.GetComponent<EnemyInteract>();
        enemyCalculate = gameObject.GetComponent<EnemyCalculate>();
    }
    public void Update()
    {
    }

    public float Enemy_Health() => enemyData.enemy_Health;
    public float Enemy_Speed() => enemyData.enemy_Speed;
    public float Enemy_AttackValue() => enemyData.enemy_AttackVaule;
    public GameObject Enenmy_Body() => enemyData.EnemyBody;
    public int WhcihDeadBody() => enemyCalculate.whichBody;
    public Transform enemyTransform => gameObject.transform;

}
