using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] int EnemyNo;
    int i = 1;
    [SerializeField] GameObject[] Enemy;
    [SerializeField] Vector2 spawnArea;
    [SerializeField] float spawnTimer;
    float timer;

    private void Start()
    {
        gameObject.GetComponent<LevelManager>().OnUpgrade += UpgradeEnemy;
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            SpawnNormalEnemy();
            //SpawnWarrior();
            timer = spawnTimer;
        }
    }

    private void UpgradeEnemy()
    {
        i = i + 1;
        spawnTimer = spawnTimer + 1;
    }

    private void SpawnNormalEnemy()
    {
        EnemyNo = Random.Range(1, i);
        Vector3 pos = new Vector3(UnityEngine.Random.Range(-spawnArea.x, spawnArea.x), UnityEngine.Random.Range(-spawnArea.y, spawnArea.y),0f);
        GameObject newEnemy = Instantiate(Enemy[EnemyNo]);
        newEnemy.transform.position = pos;
        LevelManager levelManager = FindObjectOfType<LevelManager>();
        levelManager.AddEnemyToPool(newEnemy);
    }

    private void SpawnWarrior()
    {
        EnemyNo = Random.Range(1, i);
        Vector3 pos = new Vector3(UnityEngine.Random.Range(-spawnArea.x, spawnArea.x), UnityEngine.Random.Range(-spawnArea.y, spawnArea.y), 0f);
        GameObject newEnemy = Instantiate(Enemy[EnemyNo]);
        newEnemy.transform.position = pos;
        LevelManager levelManager = FindObjectOfType<LevelManager>();
        levelManager.AddEnemyToPool(newEnemy);
    }
}
