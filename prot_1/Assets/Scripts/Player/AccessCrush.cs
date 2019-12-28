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
    public float Leapspeed;

    private NavMeshAgent m_navAgent = null;
    private CrasherAttack crasherAttack;
    private Animator animator;
    bool bTrigger;

    [SerializeField]
    SceneChanger sceneChanger;

    // Start is called before the first frame update
    void Start()
    {
        bTrigger = false;

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
        // ゴミの中身がなくなったら
        if (Garbage.Count == 0 && !bTrigger)
        {
            sceneChanger.ChangeNextSceneName("Title");
            sceneChanger.ChangeToNext();
            bTrigger = true;
            return;
        }

        // 
        if (Garbage[0] == null || Garbage[0].GetComponent<BoxCollider>().enabled == false)
            Garbage.Remove(Garbage[0]);

        // オブジェクトの移動
        m_navAgent.SetDestination(Garbage[0].transform.position);

        //// ターゲット方向のベクトルを取得,方向を、回転情報に変換
        //Vector3 relativePos = Garbage[0].transform.position - transform.position;
        //Quaternion rotation = Quaternion.LookRotation(relativePos);

        //// 現在の回転情報と、ターゲット方向の回転情報を補完する
        //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Leapspeed);

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
                        animator.SetBool("Drill", false);
                        animator.SetBool("Laser", false);
                        animator.SetBool("Hammer", true);
                    }
                    break;
                case 1:
                    if (stateInfo.shortNameHash == Animator.StringToHash("Run") || stateInfo.shortNameHash == Animator.StringToHash("Idle"))
                    {
                        animator.SetBool("Run", false);
                        animator.SetBool("Drill", true);
                        animator.SetBool("Laser", false);
                        animator.SetBool("Hammer", false);
                    }
                    break;
                //case 2:
                //    if (stateInfo.shortNameHash == Animator.StringToHash("Run") || stateInfo.shortNameHash == Animator.StringToHash("Idle"))
                //    {
                //        animator.SetBool("Run", false);
                //        animator.SetBool("Drill", false);
                //        animator.SetBool("Laser", true);
                //        animator.SetBool("Hammer", false);
                //    }
                //    break;
            }
        }

    }


}
