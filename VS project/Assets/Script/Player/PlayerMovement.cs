using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToolManager;
using System;

public class PlayerMovement : CharactorManager
{
    FindObj findObj = new FindObj();
    PlayerData playerData = new PlayerData();
    InputSystem inputSystem = new InputSystem();
    Rigidbody2D rb2D;
    TrailRenderer Tr;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        Tr = GetComponent<TrailRenderer>();
        GetManager().GetComponent<InputSystem>().OnFlip += Flip;
        //GetManager().GetComponent<InputSystem>().OnDash += Dashing;
        GetManager().GetComponent<InputSystem>().OnTurnVertical += TurnVertical;
        GetManager().GetComponent<InputSystem>().OnTurnHorizontal += TurnHorizontal;
    }
    private void FixedUpdate()
    {
        print(movementVector.x);
        ChararctorMovement();
    }
    private void TurnHorizontal(float horizontal)
    {
        print(movementVector.x);
        movementVector.x = horizontal;
    }
    private void TurnVertical(float vertical)
    {
        movementVector.y = vertical;
    }
    private void Dashing()
    {
        //StartCoroutine(Dash());
    }
    private void Flip(float mousePV)
    {
        gameObject.transform.Rotate(0f, 180f, 0f);
    }
    public new void ChararctorMovement()
    {
        Vector3 currentVector;
        currentVector = movementVector * playerData.player_Speed;
        rb2D.velocity = currentVector;
        base.ChararctorMovement();
    }

    /***************************ùSéÊ?ôΩ*****************************/
    public GameObject GetManager()
    {
        GameObject PlayerManager = findObj.FindObjectbyName("PlayerManager");
        return PlayerManager;
    }



    /*å˜î\?ôΩ*/
    //private IEnumerator Dash()
    //{
    //    playerData.canDash = false;
    //    playerData.isDashing = true;
    //    rb2D.gravityScale = 0f;
    //    rb2D.velocity = new Vector2(transform.localScale.x * playerData.dashPower, 0f);
    //    Tr.emitting = true;
    //    yield return new WaitForSeconds(playerData.dashTime);
    //    Tr.emitting = false;
    //    playerData.isDashing = false;
    //    yield return new WaitForSeconds(playerData.dashingCooldown);
    //    playerData.canDash = true;
    //}
}
