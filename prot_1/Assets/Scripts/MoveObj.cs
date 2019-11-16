using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObj : MonoBehaviour
{
    [SerializeField]
    private Vector3 m_targetPosition = Vector3.zero;
    [SerializeField]
    private float m_moveTime = 0.0f;
    [SerializeField]
    private float m_waitTime = 0.0f;

    private void Start()
    {
        StartCoroutine(Move(m_targetPosition));
    }

    private IEnumerator Move(Vector3 i_target)
    {
        Vector3 startPosition = transform.position;

        float startTime = Time.time;
        float endTime = startTime + m_moveTime;

        while (Time.time < endTime)
        {
            float elapsedTime = Time.time - startTime;
            float elapsedRate = elapsedTime / m_moveTime;

            Vector3 pos = Vector3.Lerp(startPosition, i_target, elapsedRate);
            transform.position = pos;

            yield return null;
        }

        transform.position = i_target;

        yield return new WaitForSeconds(m_waitTime);

        StartCoroutine(Move(startPosition));
    }

}
