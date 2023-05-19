using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToolManager;

public class PlayerMovement : CharactorManager
{
    FindObj findObj = new FindObj();
    PlayerData playerData = new PlayerData();

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<InputSystem>().OnFlip += Flip;
        gameObject.GetComponent<InputSystem>().OnDash += Dashing;
        gameObject.GetComponent<InputSystem>().OnTurnVertical += TurnVertical;
        gameObject.GetComponent<InputSystem>().OnTurnHorizontal += TurnHorizontal;
    }
    private void FixedUpdate()
    {
        ChararctorMovement();
    }
    private void Update()
    {
        ChararctorMovement();
    }
    private void TurnHorizontal()
    {
        movementVector.x = Input.GetAxisRaw("Horizontal");
    }
    private void TurnVertical()
    {
        movementVector.y = Input.GetAxisRaw("Vertical");
    }
    private void Dashing()
    {
        GetTrailRenderer().emitting = true;
    }
    private void Flip()
    {
        GetPlayer().transform.Rotate(0f, 180f, 0f);
    }
    public new void ChararctorMovement()
    {
        movementVector *= playerData.player_Speed;
        GetPlayerRb().velocity = movementVector;
        base.ChararctorMovement();
    }

    /***************************ùSéÊõìôΩ*****************************/
    public GameObject GetPlayer() 
    {
        GameObject player = findObj.FindObject("Player");
        return player;
    }
    public Rigidbody2D GetPlayerRb() 
    {
        Rigidbody2D rb2D = GetPlayer().GetComponent<Rigidbody2D>();
        return rb2D;
    }
    public TrailRenderer GetTrailRenderer() 
    {
        TrailRenderer Trail = GetPlayer().GetComponent<TrailRenderer>();
        return Trail;
    }

}
