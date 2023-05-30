using System.Collections.Generic;
using System.Collections;
using static InputSystem;
using UnityEngine;
using ToolManager;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyData : MonoBehaviour
{
    /************************抓取************************/
    FindObj FindObj = new FindObj();
    [field: SerializeField] Transform targetDestination;

    /************************數值************************/
    [field: SerializeField] public virtual float enemy_Health { get; set; }
    [field: SerializeField] public virtual float enemy_Speed { get; set; }
    [field: SerializeField] public virtual float enemy_AttackVaule { get; set; }
    /************************事件************************/
    

    /************************組件************************/
    Rigidbody2D rb2D;
    // Start is called before the first frame update
    protected virtual void  Start()
    {
        rb2D = this.GetComponent<Rigidbody2D>();
        targetDestination = FindObj.FindObjectbyTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        rb2D.velocity = direction * enemy_Speed;  
    }


    
}
