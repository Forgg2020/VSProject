using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float minDelay = 1f; 
    public float maxDelay = 5f; 
    private float delay; 

    private void Start()
    {
        
        delay = Random.Range(minDelay, maxDelay);

       
        InvokeRepeating("RotateObject", 0f, delay);
    }

    private void RotateObject()
    {
        Vector3 rotation = new Vector3(0f, 0f, Random.Range(0f, 360f));

        transform.rotation *= Quaternion.Euler(rotation);
    }
}
