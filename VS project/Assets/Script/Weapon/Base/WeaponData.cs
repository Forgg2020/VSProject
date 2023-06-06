using Completed;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponData : MonoBehaviour
{
    [field: SerializeField] public virtual float weapon_AttackFreq { get; set; }
    [field: SerializeField] public virtual float weapon_AttackCD { get; set; }
    [field: SerializeField] public virtual float weapon_AttackDmg { get; set; }
    [field: SerializeField] public virtual float weapon_AttackRange { get; set; }
    [field: SerializeField] public virtual float weapon_AttackRepel { get; set; }
    [field: SerializeField] public Animator weapon_Animator;


    [field: SerializeField] public SpriteRenderer spriteRenderer;
    [field: SerializeField] public AudioSource audioSource;
    public new Collider2D collider2D;
    public bool isFacingRight = false;
    public void Start()
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
            audioSource.Play();
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
