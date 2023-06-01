using System.Collections;
using System.Collections.Generic;
using ToolManager;
using UnityEngine;

public class EnemyCalculate : MonoBehaviour
{
    EnemyData enemyData = new EnemyData();
    [Header("�r�")]
    public int whichBody;
    [Header("���F")]
    public SpriteRenderer spriteRenderer;
    public float fadeDuration;
    private float timer = 0f;
    private Color startColor;
    private Color targetColor = new Color(1f, 1f, 1f, 0f);
    private void Start()
    {
        startColor = spriteRenderer.color;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void MinusHealth(float i)
    {
        
    }

    public void Dying()
    {
        whichBody = Random.Range(0, 2);
    }
    public  IEnumerator FadeOutCoroutine()
    {
        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float t = Mathf.Clamp01(timer / fadeDuration);
            spriteRenderer.color = Color.Lerp(startColor, targetColor, t);
            yield return null;
        }
    }
}
