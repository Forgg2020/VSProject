using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class FlameThrower : MonoBehaviour
{
    [SerializeField] public float weapon_AttackFreq;
    [SerializeField] public float weapon_AttackCD;
    [SerializeField] public float weapon_AttackDmg;
    [SerializeField] public float weapon_AttackRange;
    [SerializeField] public float weapon_AttackRepel;
    [SerializeField] public Animator weapon_Animator;   

    [SerializeField] public bool see;

    [SerializeField] public SpriteRenderer spriteRenderer;
    public new Collider2D collider2D;

    private void Start()
    {
        weapon_Animator = GetComponent<Animator>(); 
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
            weapon_Animator.SetBool("Atk", true);
            collider2D.enabled = true;
            spriteRenderer.enabled = true;
        }
    }

    public void AttackInCD()
    {
        weapon_AttackFreq = weapon_AttackCD;
        collider2D.enabled = false;
        spriteRenderer.enabled = false;
        weapon_Animator.SetBool("Atk", false);
    }
}
