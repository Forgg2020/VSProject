using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractObject : MonoBehaviour
{
    public SpriteRenderer mySprite;
    CapsuleCollider2D col2D;
    public Vector3 newSize;
    public Vector3 lastSize;
    AudioSource As;
    private void Start()
    {
        mySprite = gameObject.GetComponent<SpriteRenderer>();
        col2D = gameObject.GetComponent<CapsuleCollider2D>();
        As = gameObject.GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Weapon"))
        {
            StartCoroutine(Bomb());
        }
    }


    public IEnumerator Bomb() 
    {
        mySprite.sprite = null;
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        As.Play();
        col2D.size = newSize;
        yield return new WaitForSeconds(0.5f);
        col2D.size = lastSize;
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        yield return new WaitForSeconds(6f);
        Destroy(gameObject);
    }
    private void OnDestroy()
    {
    }
}
