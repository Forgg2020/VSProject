﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToolManager;
using Unity.VisualScripting;
using System.Net.NetworkInformation;

public class EnemyState : MonoBehaviour
{
    FindObj findObj = new FindObj();
    EnemyInteract enemyInteract = new EnemyInteract();

    [Header("顏色")]
    public SpriteRenderer spriteRenderer;
    public float fadeDuration = 1f;
    private float timer = 0f;
    private Color startColor;
    private Color targetColor = new Color(1f, 1f, 1f, 0f);
    public void Start()
    {
        gameObject.GetComponent<EnemyInteract>().OnGetAtk += GetHurt;
        gameObject.GetComponent<EnemyInteract>().OnDying += Dying;
        //gameObject.GetComponent<EnemyInteract>().OnGetAtk += Dying;
        spriteRenderer = GetComponent<SpriteRenderer>();
        startColor = spriteRenderer.color;

    }

    public void GetHurt(float atk)
    {
        Debug.Log("be ATKing");
    }

    public void Dying(float atk)
    {
        Destroy(EnemyData.rb2D);
        StartCoroutine(FadeOutCoroutine());
    }

    private IEnumerator FadeOutCoroutine()
    {
        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float t = Mathf.Clamp01(timer / fadeDuration);
            spriteRenderer.color = Color.Lerp(startColor, targetColor, t);
            yield return null;
        }
        Destroy(gameObject);
    }
}