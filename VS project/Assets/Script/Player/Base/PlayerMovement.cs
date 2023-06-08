using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToolManager;
using System;

public class PlayerMovement : CharactorManager
{
    PlayerDataManager playerDataManager;
    FindObj findObj = new FindObj();
    TrailRenderer Tr;
    GameObject weaponPoint;
    public Transform PlayerTransform;
    // Start is called before the first frame update
    void Start()
    {
        playerDataManager = gameObject.GetComponent<PlayerDataManager>();
        Tr = GetComponent<TrailRenderer>();
        weaponPoint = findObj.FindObjectbyName("Weapon");
        gameObject.GetComponent<InputSystem>().OnFlip += Flip;
        gameObject.GetComponent<InputSystem>().OnTurnVertical += TurnVertical;
        gameObject.GetComponent<InputSystem>().OnTurnHorizontal += TurnHorizontal;
    }
    private void FixedUpdate()
    {
        
        ChararctorMovement();
    }

    private void Update()
    {
        FacePlayer();
        PlayerTransform = gameObject.transform;
    }
    private void TurnHorizontal(float horizontal)
    {
        movementVector.x = horizontal;
    }
    private void TurnVertical(float vertical)
    {
        movementVector.y = vertical;
    }
    private void Flip(float mousePV)
    {
        gameObject.transform.Rotate(0f, 180f, 0f);
    }
    public override void ChararctorMovement()
    {
        Vector3 currentVector;
        currentVector = movementVector * playerDataManager.Player_Speed();
        playerDataManager.Player_Rb2D().velocity = currentVector;
        base.ChararctorMovement();
    }
    void FacePlayer()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = new Vector2(mousePosition.x - weaponPoint.transform.position.x, mousePosition.y - weaponPoint.transform.position.y);
        weaponPoint.transform.up = direction;
    }
}
