using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private float horizontal;
    private float speed;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;

    [SerializeField] private TrailRenderer tr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            
        }
    }
}
