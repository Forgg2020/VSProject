using System.Collections.Generic;
using System.Collections;
using static InputSystem;
using UnityEngine;
using ToolManager;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyData : MonoBehaviour
{
    /*************************引用*************************/
    FindObj findObj = new FindObj();
    public GameObject player;
    public virtual GameObject EnemyBody { get; private set; }
    /**********************SingleTon**********************/
    public static EnemyData instance;
    /************************抓取************************/
    [field: SerializeField] Transform targetDestination;
    /************************數值************************/
    [field: SerializeField] public virtual float enemy_Health { get;private set; }
    [field: SerializeField] public virtual float enemy_Speed { get; private set; }
    [field: SerializeField] public virtual float enemy_AttackVaule { get; private set; }
    /************************事件************************/
    

    /************************組件************************/
    public static Rigidbody2D rb2D;
    // Start is called before the first frame update
    protected virtual void  Start()
    {
        player = GameManager.Player;
        rb2D = this.GetComponent<Rigidbody2D>();
        targetDestination = player.transform;
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

    protected void Initialize(float health, float speed, float attackvaule, GameObject Body)
    {
        enemy_Health = health;
        enemy_Speed = speed;
        enemy_AttackVaule = attackvaule;
        EnemyBody = Body;
    }

    public void InitializeDeadBody()
    {

    }
}
