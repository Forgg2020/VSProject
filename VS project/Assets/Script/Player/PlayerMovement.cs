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
    GameObject weaponPoint;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        Tr = GetComponent<TrailRenderer>();
        weaponPoint = findObj.FindObjectbyName("Weapon");
        GetManager().GetComponent<InputSystem>().OnFlip += Flip;
        //GetManager().GetComponent<InputSystem>().OnDash += Dashing;
        GetManager().GetComponent<InputSystem>().OnTurnVertical += TurnVertical;
        GetManager().GetComponent<InputSystem>().OnTurnHorizontal += TurnHorizontal;
    }
    private void FixedUpdate()
    {
        
        ChararctorMovement();
    }

    private void Update()
    {
        FacePlayer();
    }
    private void TurnHorizontal(float horizontal)
    {
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
    public override void ChararctorMovement()
    {
        Vector3 currentVector;
        currentVector = movementVector * playerData.player_Speed;
        rb2D.velocity = currentVector;
        base.ChararctorMovement();
    }
    void FacePlayer()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = new Vector2(mousePosition.x - weaponPoint.transform.position.x, mousePosition.y - weaponPoint.transform.position.y);
        weaponPoint.transform.up = direction;
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
