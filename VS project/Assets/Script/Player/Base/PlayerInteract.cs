using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{

    public delegate void OnCollecting();
    public event OnCollecting OnHeal;
    public event OnCollecting OnSoul;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Heart"))
        {
            OnHeal?.Invoke();
        }
        if(col.CompareTag("Soul"))
        {
            OnSoul?.Invoke();
        }
    }
}
