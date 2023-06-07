using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractObject : MonoBehaviour
{
    public SpriteRenderer mySprite;
    CapsuleCollider2D col2D;
    public Vector3 newSize;
    private void Start()
    {
        mySprite = gameObject.GetComponent<SpriteRenderer>();
        col2D = gameObject.GetComponent<CapsuleCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Weapon"))
        {
            mySprite.sprite = null;
            col2D.size = newSize;
        }
    }
}
