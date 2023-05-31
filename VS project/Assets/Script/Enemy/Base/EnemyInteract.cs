using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToolManager;

public class EnemyInteract : MonoBehaviour
{
    public EnemyData enemydata;
    public delegate void OnGetAttack(float Atk);
    public event OnGetAttack OnGetAtk;
    public event OnGetAttack OnDying;
    Rigidbody2D rb2D;

    [Header("顏色")]
    public SpriteRenderer spriteRenderer;
    public float fadeDuration = 1f;
    private float timer = 0f;
    private Color startColor;
    private Color targetColor = new Color(1f, 1f, 1f, 0f);

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemydata = gameObject.GetComponent<EnemyData>();
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            Geturt(other.gameObject);
        }
    }
    private void Geturt(GameObject colObj)
    {
        WeaponData weaponDataScript = colObj.gameObject.GetComponent<WeaponData>();
        enemydata.MinusHealth(weaponDataScript.weapon_AttackDmg);
        if(enemydata.enemy_Health <= 0)
        {
            rb2D.simulated = false;
            StartCoroutine(FadeOutCoroutine());
        }
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