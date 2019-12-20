using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrasherAttack : MonoBehaviour
{
    private AudioSource audio;
    private Animator animator;
    public GameObject PunchCollider;
    public GameObject PunchLeftCollider;
    public GameObject DrillCollider;
    public GameObject HammerCollider;
    public GameObject LaserObj;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        PunchCollider.SetActive(false);
        PunchLeftCollider.SetActive(false);
        DrillCollider.SetActive(false);
        HammerCollider.SetActive(false);
        LaserObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerInputManager.GetEnabled())
            return;

        if (Input.GetKeyDown(KeyCode.P) || Input.GetButtonDown("Attack"))
        {
            if (!animator.GetBool("Punch"))
                audio.Play();

            Punch();
        }

        if (Input.GetKeyDown(KeyCode.P) || Input.GetButtonDown("Laser"))
        {
            if (!animator.GetBool("Laser"))
                audio.Play();

            Laser();
        }

        if (Input.GetKeyDown(KeyCode.P) || Input.GetButtonDown("Hammer"))
        {
            if (!animator.GetBool("Hammer"))
                audio.Play();

            Hammer();
        }

        if (Input.GetKeyDown(KeyCode.P) || Input.GetButtonDown("Drill"))
        {
            if (!animator.GetBool("Drill"))
                audio.Play();

            Drill();
        }
    }

    void Punch()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.shortNameHash == Animator.StringToHash("Run") || stateInfo.shortNameHash == Animator.StringToHash("Idle") || stateInfo.shortNameHash == Animator.StringToHash("Punch") || stateInfo.shortNameHash == Animator.StringToHash("Punch1"))
        {
            animator.SetBool("Run", false);
            animator.SetBool("Punch", true);
        }
        if(stateInfo.shortNameHash == Animator.StringToHash("Punch1"))
        {
            animator.SetBool("Run", false);
            animator.SetBool("Punch", true);
        }
    }

    void Laser()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.shortNameHash == Animator.StringToHash("Run") || stateInfo.shortNameHash == Animator.StringToHash("Idle"))
        {
            animator.SetBool("Run", false);
            animator.SetBool("Laser", true);
        }
    }

    void Hammer()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.shortNameHash == Animator.StringToHash("Run") || stateInfo.shortNameHash == Animator.StringToHash("Idle"))
        {
            animator.SetBool("Run", false);
            animator.SetBool("Hammer", true);
        }
    }

    void Drill()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.shortNameHash == Animator.StringToHash("Run") || stateInfo.shortNameHash == Animator.StringToHash("Idle"))
        {
            animator.SetBool("Run", false);
            animator.SetBool("Drill", true);
        }
    }

    void PunchColliderOn()
    {
        PunchCollider.SetActive(true);
    }

    void PunchColliderOff()
    {
        PunchCollider.SetActive(false);
    }

    void PunchLeftColliderOn()
    {
        PunchLeftCollider.SetActive(true);
    }

    void PunchLeftColliderOff()
    {
        PunchLeftCollider.SetActive(false);
    }

    void DrillColliderOn()
    {
        DrillCollider.SetActive(true);
    }

    void DrillColliderOff()
    {
        DrillCollider.SetActive(false);
    }

    void HammerColliderOn()
    {
        HammerCollider.SetActive(true);
    }

    void HammerColliderOff()
    {
        HammerCollider.SetActive(false);
    }

    void LaserOn()
    {
        LaserObj.SetActive(true);
    }

    void LaserOff()
    {
        LaserObj.SetActive(false);
    }
}
