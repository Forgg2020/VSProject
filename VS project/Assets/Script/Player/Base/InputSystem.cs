using System.Collections;
using System.Collections.Generic;
using ToolManager;
using UnityEngine;
using UnityEngine.Video;

public class InputSystem : MonoBehaviour 
{
    PlayerDataManager playerDataManager;
    /********************à⁄ìÆ********************/
    public delegate void OnInputEvent(float i);
    public event OnInputEvent OnTurnHorizontal;
    public event OnInputEvent OnTurnVertical;
    public event OnInputEvent OnFlip;
    //public event OnInputEvent OnDash;

    /********************Ázå¸********************/    
    public bool isFacingRight = true;

    /********************è’éh********************/

    /********************à íu********************/
    public  Transform PlayerTran;

    private void Update()
    {
        //Dash();
        Flip();
        TurnVertical();
        TurnHorizontal();
        PlayerTran = FindObjectOfType<PlayerMovement>().transform;
    }
    public void TurnHorizontal()//?ïΩà⁄ìÆ
    {
        var horizontal = Input.GetAxis("Horizontal");
        if (horizontal != 0)
        {
            OnTurnHorizontal?.Invoke(horizontal);
        }
    }
    public void TurnVertical()//?íºà⁄ìÆ
    {
        var vertical = Input.GetAxis("Vertical");
        if (vertical != 0)
        {
            OnTurnVertical?.Invoke(vertical);
        }
    }
    //public void Dash()//è’éh
    //{
    //    if (Input.GetKeyDown(KeyCode.Space) && playerData.canDash)
    //    {            
    //        OnDash?.Invoke();
    //    }
    //}
    public void Flip()//Ázå¸
    {
        var mousePos = Input.mousePosition;
        float mousePV = 500;
        if (mousePos.x < mousePV && isFacingRight)
        {
            OnFlip?.Invoke(mousePV);
            isFacingRight = !isFacingRight;
        }
        else if (mousePos.x > mousePV && !isFacingRight)
        {
            OnFlip?.Invoke(mousePV);
            isFacingRight = !isFacingRight;
        }
    }    
}
