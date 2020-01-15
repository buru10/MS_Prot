using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RisaAnimSpawn : MonoBehaviour
{
    public RisaSpawnerAnimation risaSpawnerAnimation;
    public float MoveDistance = 3.0f;
    private Vector3 start, end;
    public float AnimTime = 2.0f;
    float nowTime = 0.0f;
    bool Done = false;
    bool bAnim = false;

    private void OnEnable()
    {
        bAnim = true;
        bool Done = false;
        start = transform.position;
        end = transform.position + transform.forward.normalized * MoveDistance;
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<RisaikuruRecovery>().enabled = false;

        risaSpawnerAnimation = GameObject.Find("RisaSpawner").GetComponent<RisaSpawnerAnimation>();
    }
    // Start is called before the first frame update 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Done)
        {
            this.enabled = false;
        }

        if(bAnim)
        {
            nowTime += Time.deltaTime;
            if(nowTime >= AnimTime)
            {
                nowTime = AnimTime;
                Done = true;
                transform.position = Vector3.Lerp(start, end, nowTime / AnimTime);

                GetComponent<NavMeshAgent>().enabled = true;
                GetComponent<RisaikuruRecovery>().enabled = true;
                risaSpawnerAnimation.Close();
            }
            else
                transform.position = Vector3.Lerp(start, end, nowTime / AnimTime);
        }
    }
}
