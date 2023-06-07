using Completed;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : WeaponData
{
    public float speed = 10f;
    public float lifetime = 3f;
    public int damage = 1;

    public Vector2 direction;
    public Vector3 PlayerVec;
    public GameObject PlayerObj;
    private new void Start()
    {
        PlayerObj = GameObject.FindGameObjectWithTag("Player");
        PlayerVec = PlayerObj.transform.rotation.eulerAngles;
        Destroy(gameObject, lifetime);
    }

     void Update()
    {
        // 在 Update 函數中更新子彈的位置
        GetFlip(500);
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);

        }
    }
    public void GetFlip(float mouse)//轉向
    {
        if (PlayerVec.y == 180)
        {
            print("右");
            direction = Vector2.right;
        }
        else
        {
            print("左");
            direction = Vector2.left;
        }
    }
}
