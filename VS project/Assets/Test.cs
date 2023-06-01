using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    Animator anim;
    public int i;
    // Start is called before the first frame update
    void Start()
    {
        i = Random.Range(0, 2);
        anim = GetComponent<Animator>();
        anim.SetInteger("Test", i);
    }

}
