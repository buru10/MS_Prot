using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RisaLeap : MonoBehaviour
{
    // メンバ変数
    public Transform endMarker;
    private NavMeshAgent m_navAgent = null;


    // Start is called before the first frame update
    void Start()
    {
        // 初期化
        m_navAgent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        // オブジェクトの移動
        m_navAgent.SetDestination(endMarker.transform.position);

    }
}
