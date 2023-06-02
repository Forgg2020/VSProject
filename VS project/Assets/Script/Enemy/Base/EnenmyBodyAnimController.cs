using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnenmyBodyAnimController : MonoBehaviour
{
    // Start is called before the first frame update
    Animator Anim;
    public int i;
    void Start()
    {
        Anim = GetComponent<Animator>();
        i = Random.Range(0, 2);
        Anim.SetInteger("Which", i);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
