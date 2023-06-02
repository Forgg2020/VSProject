using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToolManager;
using Unity.VisualScripting;
using System.Net.NetworkInformation;

public class EnemyState : MonoBehaviour
{
    EnemyData enemyData;
    FindObj findObj = new FindObj();
    public EnemyCalculate enemyCalculate;
    Rigidbody2D rb2D;
    [Header("顏色")]
    public SpriteRenderer spriteRenderer;
    public float fadeDuration;
    private Color startColor;
    private Color targetColor = new Color(1f, 1f, 1f, 0f);

    [Header("掉落")]
    public GameObject[] Item;
    public int dropRate;
    public Transform bodyTransform;

    [Header("死亡")]
    public bool isDead = false;
    public void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        enemyData = gameObject.GetComponent<EnemyData>();
        enemyCalculate = gameObject.GetComponent<EnemyCalculate>();
        gameObject.GetComponent<EnemyInteract>().OnDead += Dying;
        spriteRenderer = GetComponent<SpriteRenderer>();
        startColor = spriteRenderer.color;
    }
    public void Dying()
    {
        isDead = true;
        rb2D.simulated = false;
        Color color = spriteRenderer.color;
        color.a = 0;
        spriteRenderer.color = color;
        var bodyObj = enemyData.EnemyBody;
        var body = enemyCalculate.whichBody;
        Instantiate(bodyObj, gameObject.transform);
        StartCoroutine(FadeOutCoroutine());
        bodyTransform = gameObject.transform;
        DropItem();

    }
    public IEnumerator FadeOutCoroutine()
    {
        float timer = 0;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float t = Mathf.Clamp01(timer / fadeDuration);
            spriteRenderer.color = Color.Lerp(startColor, targetColor, t);
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
            GameObject newItem = Instantiate(Item[i], bodyTransform.transform.position, Quaternion.identity, null);
        }
    }
}