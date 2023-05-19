using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class InputSystem : MonoBehaviour
{
    /********************ˆÚ“®********************/
    public delegate void OnInputEvent();
    public event OnInputEvent OnTurnHorizontal;
    public event OnInputEvent OnTurnVertical;
    public event OnInputEvent OnDash;
    public event OnInputEvent OnFlip;

    /********************çzŒü********************/


    private void Update()
    {
        Dash();
        Flip();
        TurnVertical();
        TurnHorizontal();
    }
    public void TurnHorizontal()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            OnTurnHorizontal?.Invoke();
        }
    }
    public void TurnVertical()
    {
        if (Input.GetAxis("Vertical") != 0)
        {
            OnTurnVertical?.Invoke();
        }
    }
    public void Dash()
    {
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            OnDash?.Invoke();
        }
    }
    public void Flip()
    {
        bool isFacingRight = true;
        var mousePos = Input.mousePosition;
        int mousePV = 500;
        print(Input.mousePosition);
        if(mousePos.x < mousePV && isFacingRight)
        {            
            isFacingRight = !isFacingRight;
            OnFlip?.Invoke();
        }else if(mousePos.x > mousePV && !isFacingRight) 
        {
            isFacingRight = !isFacingRight;
            OnFlip?.Invoke();
        }
    }
}
