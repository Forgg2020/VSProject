using System.Collections.Generic;
using System.Collections;
using static InputSystem;
using UnityEngine;
using ToolManager;
using UnityEditor;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyData : MonoBehaviour
{
    /*************************引用*************************/
    public GameObject player;
    public Animator Anim;
    public Rigidbody2D rb2D;
    public SpriteRenderer BodySprite;
    public int i;
    public int j;
    public GameObject DeadBodyObj;
    public Sprite[] DeadBodysprite;
    EnemyDataManager enemyDataManager;
    /**********************SingleTon**********************/
    public static EnemyData instance;
    /************************抓取************************/
    [field: SerializeField] Transform targetDestination;
    /************************數值************************/
    [field: SerializeField] public virtual float enemy_Health { get;  set; }
    [field: SerializeField] public virtual float enemy_Speed { get;  set; }
    [field: SerializeField] public virtual float enemy_AttackVaule { get;  set; }
    [field: SerializeField] public virtual GameObject EnemyBody { get;  set; }
    //[field: SerializeField] public virtual SpriteRenderer BodySprite { get;  set; }
    [field: SerializeField] public virtual int DropRateNum { get; private set; }

    public Transform EnemyTransform;
    /************************事件************************/


    /************************組件************************/
    protected virtual void Start()
    {
        BodySprite = gameObject.GetComponent<SpriteRenderer>();
        enemyDataManager = gameObject.GetComponent<EnemyDataManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        rb2D.velocity = direction * enemy_Speed;
        EnemyTransform = gameObject.transform;
    }
    public void MinusHealth(float i)
    {
        enemy_Health -= i;
    }

    public void Initialize(float health, float speed, float attackvaule,GameObject enemyBody)
    {
        enemy_Health = health;
        enemy_Speed = speed;
        enemy_AttackVaule = attackvaule;
        EnemyBody = enemyBody;
    }
}
