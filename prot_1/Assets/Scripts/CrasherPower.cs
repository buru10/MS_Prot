using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrasherPower : MonoBehaviour
{
    // メンバ変数定義
    private Animator animator;
    public Animator AIanimator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        if (!AIanimator)
            foreach (Transform child in transform)
            {
                if ("AI_00" == child.name)
                    AIanimator = child.GetComponent<Animator>();
            }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void On()
    {
        animator.SetBool("TurnOn",true);
    }

    public void Off()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.shortNameHash == Animator.StringToHash("Run") || stateInfo.shortNameHash == Animator.StringToHash("Idle"))
        {
            animator.SetBool("Run", false);
            animator.SetBool("TurnOff", true);
            AIanimator.SetBool("Out", true);
        }
    }
}
