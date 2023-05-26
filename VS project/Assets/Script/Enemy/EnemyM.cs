using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToolManager;
using static InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyM : MonoBehaviour
{
    FindObj FindObj = new FindObj();
    [SerializeField] float speed;
    [SerializeField] Transform targetDestination;

    public delegate void OnGetAttack();
    public event OnGetAttack OnGetAtk;

    Rigidbody2D rb2D;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        targetDestination = FindObj.FindObjectbyTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        rb2D.velocity = direction * speed;  
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            OnGetAtk?.Invoke();
        }
    }
}
