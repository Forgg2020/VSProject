﻿using Completed;
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
    PlayerBuff playerBuff;
    protected override void Start()
    {
        playerBuff = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBuff>();
        PlayerObj = GameObject.FindGameObjectWithTag("Player");
        PlayerVec = PlayerObj.transform.rotation.eulerAngles;
        Destroy(gameObject, lifetime);
        weapon_AttackFreq = 2;
        weapon_AttackCD = 2;
        weapon_AttackDmg = 0f + playerBuff.Weapon_ExtraAtkValue;
        weapon_AttackRange = 10;
        weapon_AttackRepel = 10;
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
            direction = Vector2.right;
        }
        else
        {
            direction = Vector2.left;
        }
    }
}
