using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{

    public delegate void OnPicking(GameObject colObj);
    public event OnPicking OnPick;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
