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
    FindObj findObj = new FindObj();
    public GameObject player;
    public Animator Anim;
    public EnemyCalculate enemyCalculate;
    /**********************SingleTon**********************/
    public static EnemyData instance;
    /************************抓取************************/
    [field: SerializeField] Transform targetDestination;
    /************************數值************************/
    [field: SerializeField] public virtual float enemy_Health { get; private set; }
    [field: SerializeField] public virtual float enemy_Speed { get; private set; }
    [field: SerializeField] public virtual float enemy_AttackVaule { get; private set; }
    [field: SerializeField] public virtual GameObject EnemyBody { get; private set; }
    [field: SerializeField] public virtual SpriteRenderer BodySprite { get; private set; }
    [field: SerializeField] public virtual int DropRateNum { get; private set; }
    /************************事件************************/


    /************************組件************************/
    public Rigidbody2D rb2D;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        player = GameManager.Player;
        rb2D = this.GetComponent<Rigidbody2D>();
        targetDestination = player.transform;
        enemyCalculate = gameObject.GetComponent<EnemyCalculate>();

        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        rb2D.velocity = direction * enemy_Speed;
    }
    public void MinusHealth(float i)
    {
        enemy_Health -= i;
    }

    protected void Initialize(float health, float speed, float attackvaule,GameObject enemyBody)
    {
        enemy_Health = health;
        enemy_Speed = speed;
        enemy_AttackVaule = attackvaule;
        EnemyBody = enemyBody;
    }
    protected void GetSprite(int i,GameObject BodyObj,Sprite sp01, Sprite sp02)
    {
        GameObject BodySplit0 = BodyObj.transform.GetChild(0).gameObject;
        GameObject BodySplit1 = BodyObj.transform.GetChild(1).gameObject;
        SpriteRenderer SR01 = BodySplit0.GetComponent<SpriteRenderer>();
        SpriteRenderer SR02 = BodySplit1.GetComponent<SpriteRenderer>();
        SR01.sprite = sp01;
        SR02.sprite = sp02;
    }
}
