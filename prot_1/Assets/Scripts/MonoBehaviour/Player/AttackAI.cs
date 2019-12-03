using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAI : MonoBehaviour
{
    private Animator animator;
    public GameObject jabCollider;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        jabCollider.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerInputManager.GetEnabled())
            return;

        if (Input.GetKeyDown(KeyCode.P) || Input.GetButtonDown("Attack"))
        {
            Attack();
        }
    }

    void Attack()
    {
        animator.SetBool("Run", false);
        animator.SetBool("Attack", true);
    }

    void AttackColliderOn()
    {
        jabCollider.SetActive(true);
    }

    void AttackColliderOff()
    {
        jabCollider.SetActive(false);
    }
}
