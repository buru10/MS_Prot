using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAnimation : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("In", true);
        animator.SetBool("Out", false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void  AIInStart()
    {
        animator.SetBool("In", true);
    }
    public void AIInEnd()
    {
       // animator.SetBool("In", false);
        animator.SetBool("Out", true);
    }

    public void AIOutStart()
    {
        animator.SetBool("Out", true);
    }
    public void AIOutEnd()
    {
        animator.SetBool("In", true);
        animator.SetBool("Out", false);
    }


}
