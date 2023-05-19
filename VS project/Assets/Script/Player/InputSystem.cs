using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class InputSystem : MonoBehaviour
{

    PlayerData playerData = new PlayerData();
    /********************à⁄ìÆ********************/
    public delegate void OnInputEvent(float i);
    public event OnInputEvent OnTurnHorizontal;
    public event OnInputEvent OnTurnVertical;
    public event OnInputEvent OnFlip;
    //public event OnInputEvent OnDash;

    /********************Ázå¸********************/    
    public bool isFacingRight = true;

    /********************è’éh********************/

    private void Update()
    {
        //Dash();
        Flip();
        TurnVertical();
        TurnHorizontal();
    }
    public void TurnHorizontal()
    {
        var horizontal = Input.GetAxis("Horizontal");
        if (horizontal != 0)
        {
            OnTurnHorizontal?.Invoke(horizontal);
            print(horizontal);
        }
    }
    public void TurnVertical()
    {
        var vertical = Input.GetAxis("Vertical");
        if (vertical != 0)
        {
            OnTurnVertical?.Invoke(vertical);
            print(vertical);
        }
    }
    //public void Dash()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space) && playerData.canDash)
    //    {            
    //        OnDash?.Invoke();
    //    }
    //}
    public void Flip()
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
