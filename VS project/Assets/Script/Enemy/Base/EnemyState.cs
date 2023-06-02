using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToolManager;
using Unity.VisualScripting;
using System.Net.NetworkInformation;

public class EnemyState : MonoBehaviour
{
    EnemyDataManager enemyDataManager;
    [Header("顏色")]
    public float fadeDuration;
    private Color startColor;
    private Color targetColor = new Color(1f, 1f, 1f, 0f);

    [Header("掉落")]
    public GameObject[] Item;
    public int dropRate;

    [Header("死亡")]
    public bool isDead = false;
    public void Start()
    {
        enemyDataManager = GetComponent<EnemyDataManager>();
        gameObject.GetComponent<EnemyInteract>().OnDead += Dying;
        startColor = enemyDataManager.Enemy_SpirtRenderer().color;
    }
    public void Dying()
    {
        isDead = true;
        enemyDataManager.Enenmy_Rb2D().simulated = false;
        Color color = enemyDataManager.Enemy_SpirtRenderer().color;
        color.a = 0;
        enemyDataManager.Enemy_SpirtRenderer().color = color;
        var bodyObj = enemyDataManager.Enenmy_Body();
        var body = enemyDataManager.WhcihDeadBody();
        Instantiate(bodyObj, gameObject.transform);
        StartCoroutine(FadeOutCoroutine());
        DropItem();

    }
    public IEnumerator FadeOutCoroutine()
    {
        float timer = 0;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float t = Mathf.Clamp01(timer / fadeDuration);
            enemyDataManager.Enemy_SpirtRenderer().color = Color.Lerp(startColor, targetColor, t);
            yield return null;
        }
        Destroy(gameObject);
    }

    public void DropItem()
    {
        int i;
        dropRate = Random.Range(0, 2);
        if( dropRate == 0 )
        {
            i = Random.Range(0, 2);
            GameObject newItem = Instantiate(Item[i], enemyDataManager.EnemyTransform().position, Quaternion.identity, null);
        }
    }
}