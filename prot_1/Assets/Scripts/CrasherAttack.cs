using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrasherAttack : MonoBehaviour
{
    public AudioSource[] audio;
    private Animator animator;
    public GameObject PunchCollider;
    public GameObject PunchLeftCollider;
    public GameObject DrillCollider;
    public GameObject HammerCollider;
    public GameObject HammerParticle;
    public GameObject LaserObj;
    public GameObject Laser360LObj;
    public GameObject Laser360RObj;
    public Shovel ShovelCollider;

    // Start is called before the first frame update
    void Start()
    {
        //audio = GetComponent<AudioSource>();

        animator = GetComponent<Animator>();
        PunchCollider.SetActive(false);
        PunchLeftCollider.SetActive(false);
        DrillCollider.SetActive(false);
        HammerCollider.SetActive(false);
        LaserObj.SetActive(false);
        Laser360LObj.SetActive(false);
        Laser360RObj.SetActive(false);
        ShovelCollider.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerInputManager.GetEnabled())
            return;

        if (Input.GetKeyDown(KeyCode.P) || Input.GetButtonDown("Attack"))
        {
            if (!animator.GetBool("Punch"))
                audio[0].Play();

            Punch();
        }

        else if (Input.GetKeyDown(KeyCode.P) || Input.GetButtonDown("Laser"))
        {
            if (!animator.GetBool("Laser"))
                audio[1].Play();

            Laser();
        }

        else if (Input.GetKeyDown(KeyCode.P) || Input.GetButtonDown("Hammer"))
        {
            if (!animator.GetBool("Hammer"))
                audio[0].Play();

            Hammer();
        }

        else if (Input.GetKeyDown(KeyCode.P) || Input.GetButtonDown("Drill"))
        {
            if (!animator.GetBool("Drill"))
                audio[2].Play();

            Drill();
        }

        else if (Input.GetButtonDown("Laser360"))
        {
            if (!animator.GetBool("Laser360"))
                audio[1].Play();

            Laser360();
        }

        else if (Input.GetButtonDown("Shovel"))
        {
            if (!animator.GetBool("Shovel"))
                audio[0].Play();

            Shovel();
        }

        if (Input.GetButtonUp("Shovel"))
        {
            ShovelOff();
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

    void Laser360()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.shortNameHash == Animator.StringToHash("Run") || stateInfo.shortNameHash == Animator.StringToHash("Idle"))
        {
            animator.SetBool("Run", false);
            animator.SetBool("Laser360", true);
        }
    }

    void Shovel()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.shortNameHash == Animator.StringToHash("Run") || stateInfo.shortNameHash == Animator.StringToHash("Idle"))
        {
            animator.SetBool("Run", false);
            animator.SetBool("Shovel", true);
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
        Instantiate(HammerParticle,HammerCollider.transform.position, Quaternion.identity);
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

    void Laser360On()
    {
        Laser360LObj.SetActive(true);
        Laser360RObj.SetActive(true);
    }

    void Laser360Off()
    {
        Laser360LObj.SetActive(false);
        Laser360RObj.SetActive(false);
    }

    void ShovelOn()
    {
        ShovelCollider.gameObject.SetActive(true);
        GetComponent<PlayerAIMove>().ShovelMoveStart();
    }

    void ShovelOff()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        //if (stateInfo.shortNameHash == Animator.StringToHash("Shovel") || stateInfo.shortNameHash == Animator.StringToHash("Shovel001"))
        {
            animator.SetBool("Shovel", false);
            ShovelCollider.ShovelOff();
            ShovelCollider.gameObject.SetActive(false);
            GetComponent<PlayerAIMove>().ShovelMoveEnd();
        }
    }

}
