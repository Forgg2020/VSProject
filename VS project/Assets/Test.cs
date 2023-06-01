using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public float fadeDuration;
    private float timer = 0f;
    private Color startColor;
    private Color targetColor = new Color(1f, 1f, 1f, 0f);
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        startColor = spriteRenderer.color;
        StartCoroutine(FadeOutCoroutine());
    }

    public IEnumerator FadeOutCoroutine()
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
