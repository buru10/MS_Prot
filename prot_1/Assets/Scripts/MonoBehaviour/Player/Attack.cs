using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
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
        if(Input.GetKeyDown(KeyCode.P) || Input.GetButtonDown("Attack"))
        {
            jab();
        }
    }

    void jab()
    {
        animator.SetBool("Run", false);
        animator.SetBool("Jab", true);
    }

    void JabColliderOn()
    {
        jabCollider.SetActive(true);
    }

    void JabColliderOff()
    {
        jabCollider.SetActive(false);
    }
}
