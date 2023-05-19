using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorManager : MonoBehaviour
{
    public Vector3 movementVector;

    private void Start()
    {
        movementVector = new Vector3();
    }
    public virtual void ChararctorMovement()
    {
        
    }
}
