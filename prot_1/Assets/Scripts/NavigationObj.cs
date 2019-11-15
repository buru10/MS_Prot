using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

[RequireComponent(typeof(NavMeshAgent))]
public class NavigationObj : MonoBehaviour
{
    [SerializeField]
    private Transform m_target = null;

    private NavMeshAgent m_navAgent = null;

    private void Start()
    {
        m_navAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (m_target != null)
        {
            m_navAgent.destination = m_target.position;
        }
    }
}
