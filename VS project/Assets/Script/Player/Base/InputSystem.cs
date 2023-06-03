using System.Collections;
using System.Collections.Generic;
using ToolManager;
using UnityEngine;
using UnityEngine.Video;

public class InputSystem : MonoBehaviour 
{
    PlayerDataManager playerDataManager;
    /********************�ړ�********************/
    public delegate void OnInputEvent(float i);
    public event OnInputEvent OnTurnHorizontal;
    public event OnInputEvent OnTurnVertical;
    public event OnInputEvent OnFlip;
    //public event OnInputEvent OnDash;

    /********************�z��********************/    
    public bool isFacingRight = true;

    /********************�Վh********************/

    /********************�ʒu********************/
    public  Transform PlayerTran;

    private void Update()
    {
        //Dash();
        Flip();
        TurnVertical();
        TurnHorizontal();
        PlayerTran = FindObjectOfType<PlayerMovement>().transform;
    }
    public void TurnHorizontal()//?���ړ�
    {
        var horizontal = Input.GetAxis("Horizontal");
        if (horizontal != 0)
        {
            OnTurnHorizontal?.Invoke(horizontal);
        }
    }
    public void TurnVertical()//?���ړ�
    {
        var vertical = Input.GetAxis("Vertical");
        if (vertical != 0)
        {
            OnTurnVertical?.Invoke(vertical);
        }
    }
    //public void Dash()//�Վh
    //{
    //    if (Input.GetKeyDown(KeyCode.Space) && playerData.canDash)
    //    {            
    //        OnDash?.Invoke();
    //    }
    //}
    public void Flip()//�z��
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
