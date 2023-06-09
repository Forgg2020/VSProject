using System.Collections;
using System.Collections.Generic;
using ToolManager;
using UnityEngine;
using UnityEngine.Video;

public class InputSystem : MonoBehaviour 
{
    PlayerDataManager playerDataManager;
    /********************移動********************/
    public delegate void OnInputEvent(float i);
    public event OnInputEvent OnTurnHorizontal;
    public event OnInputEvent OnTurnVertical;
    public event OnInputEvent OnFlip;
    //public event OnInputEvent OnDash;

    /********************轉向********************/    
    public bool isFacingRight = true;

    /********************衝刺********************/

    /********************位置********************/
    public  Transform PlayerTran;

    private void Update()
    {
        //Dash();
        Flip();
        TurnVertical();
        TurnHorizontal();
        PlayerTran = FindObjectOfType<PlayerMovement>().transform;
    }
    public void TurnHorizontal()//?平移動
    {
        var horizontal = Input.GetAxis("Horizontal");
        if (horizontal != 0)
        {
            OnTurnHorizontal?.Invoke(horizontal);
        }
    }
    public void TurnVertical()//?直移動
    {
        var vertical = Input.GetAxis("Vertical");
        if (vertical != 0)
        {
            OnTurnVertical?.Invoke(vertical);
        }
    }
    public void Flip()//轉向
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
