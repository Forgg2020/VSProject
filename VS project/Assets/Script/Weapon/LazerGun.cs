using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class LazerGun : WeaponData
{
    public GameObject BulletPrefab;
    public GameObject BulletObj;
    public GameObject LaserGun;
    public new void Start()
    {
        weapon_Animator = gameObject.GetComponent<Animator>();
        weapon_AttackFreq = 2;
        weapon_AttackCD = 2;
        weapon_AttackDmg = 10f;
        weapon_AttackRange = 10;
        weapon_AttackRepel = 10;
        spriteRenderer = LaserGun.GetComponent<SpriteRenderer>();
    }

    public void Shooting()
    {
        Instantiate(BulletPrefab, BulletObj.transform.position, BulletObj.transform.rotation, null);
    }

    private void Update()
    {
        Attacking();
    }
    public void Attacking()
    {
        weapon_AttackFreq -= Time.deltaTime;
        if (weapon_AttackFreq <= 0)
        {
            spriteRenderer.enabled = true;
            audioSource.Play();
            weapon_Animator.SetBool("Atk", true);
            collider2D.enabled = true;
        }
    }

    public void AttackInCD()
    {
        weapon_AttackFreq = weapon_AttackCD;
        collider2D.enabled = false;
        spriteRenderer.enabled = false;
        weapon_Animator.SetBool("Atk", false);
        Attacking();
    }
}
