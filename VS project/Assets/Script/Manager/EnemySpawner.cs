﻿using Completed;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    LevelDataManager levelDataManager;
    [SerializeField] int EnemyNo;
    [SerializeField] float spawnTimer;
    [SerializeField] GameObject[] Enemy;
    [SerializeField] Vector2 spawnArea;
    public int i = 1;
    float timer;
    public GameObject[] Panel;
    private void Start()
    {
        levelDataManager = gameObject.AddComponent<LevelDataManager>();
        gameObject.GetComponent<LevelState>().OnUpgrade += UpgradeEnemy;
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            SpawnNormalEnemy();
            timer = spawnTimer;
        }
    }
    private void UpgradeEnemy()
    {
        Panel[0].SetActive(true);
        Time.timeScale = 0f;
        if (i < 5)
        {
            i = i + 1;
            spawnTimer = spawnTimer + 1;
        }
    }
    private void SpawnNormalEnemy()
    {
        EnemyNo = Random.Range(1, i);
        Vector3 pos = Vector3.zero;
        bool validPosition = false;

        while (!validPosition)
        {
            pos = new Vector3(Random.Range(-spawnArea.x, spawnArea.x), Random.Range(-spawnArea.y, spawnArea.y), 0f);

            if (Vector3.Distance(pos, levelDataManager.Player().transform.position) >= 10f)
            {
                validPosition = true;
            }
        }

        GameObject newEnemy = Instantiate(Enemy[EnemyNo]);
        newEnemy.transform.position = pos;

        LevelState levelManager = FindObjectOfType<LevelState>();
        levelManager.AddEnemyToPool(newEnemy);
    }
    private void SpawnWarrior()
    {
        EnemyNo = Random.Range(1, i);
        Vector3 pos = new Vector3(Random.Range(-spawnArea.x, spawnArea.x), Random.Range(-spawnArea.y, spawnArea.y), 0f);
        GameObject newEnemy = Instantiate(Enemy[EnemyNo]);
        newEnemy.transform.position = pos;
        LevelState levelManager = FindObjectOfType<LevelState>();
        levelManager.AddEnemyToPool(newEnemy);
    }
}
