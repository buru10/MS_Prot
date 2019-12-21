using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    public StageStateManager ssm;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //animator.SetBool("In", true);
        //animator.SetBool("Out", false);
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
        ssm.ChangeState(StageStateManager.StageState.Ready);
        // animator.SetBool("In", false);
        //animator.SetBool("Out", true);
    }

    public void AIOutStart()
    {
        animator.SetBool("Out", true);
    }

    public void AIOutEnd()
    {
        ssm.ChangeState(StageStateManager.StageState.Finish);
        //animator.SetBool("In", true);
        //animator.SetBool("Out", false);
    }


}
