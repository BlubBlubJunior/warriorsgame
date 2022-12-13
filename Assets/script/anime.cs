using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anime : MonoBehaviour
{
    public float speed = 3;
    private Animator animator;
    

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetFloat("speed", 0);
        
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetFloat("speed", 1);

        }
        if (Input.GetKey(KeyCode.S))
        {
            animator.SetFloat("speed", -1);

        }
       
    }
}
