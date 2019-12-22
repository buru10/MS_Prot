using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AccessCrush : MonoBehaviour
{
    // メンバー変数定義
    public GameObject GarbageObj;
    public List<GameObject> Garbage = new List<GameObject>();

    public float disSize=5.0f;

    private NavMeshAgent m_navAgent = null;
    private CrasherAttack crasherAttack;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        // 子供の情報を受け取る
        foreach (Transform child in GarbageObj.transform)
        {
            Garbage.Add(child.gameObject);
            foreach (Transform mago in child.transform)
            {
                if(mago.tag == "BurstObject")
                {
                    Garbage.Add(mago.gameObject);
                }
            }
        }

        m_navAgent = GetComponent<NavMeshAgent>();
        crasherAttack = GetComponent<CrasherAttack>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // 
        if (Garbage[0] == null || Garbage[0].GetComponent<BoxCollider>().enabled == false)
            Garbage.Remove(Garbage[0]);

        // オブジェクトの移動
        m_navAgent.SetDestination(Garbage[0].transform.position);

        // ふたつのオブジェクトの線分
        Vector3 Apos = transform.position;
        Vector3 Bpos = Garbage[0].transform.position;

        if (disSize >= Vector3.Distance(Apos, Bpos))
        {
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            switch (Random.Range(0, 2))
            {
                case 0:
                    if (stateInfo.shortNameHash == Animator.StringToHash("Run") || stateInfo.shortNameHash == Animator.StringToHash("Idle"))
                    {
                        animator.SetBool("Run", false);
                        animator.SetBool("Hammer", true);
                    }
                    break;
                case 1:
                    if (stateInfo.shortNameHash == Animator.StringToHash("Run") || stateInfo.shortNameHash == Animator.StringToHash("Idle"))
                    {
                        animator.SetBool("Run", false);
                        animator.SetBool("Drill", true);
                    }
                    break;
            }
        } 
    }


}
