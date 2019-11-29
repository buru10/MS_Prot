// 子オブジェクトのBurst関数を呼び出すクラス

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstFragChild : MonoBehaviour
{
    [SerializeField]
    List<GameObject> Children;
    [SerializeField]
    int minForce = -3;
    [SerializeField]
    int maxForce = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            BurstChildren();
        }
    }

    void BurstChildren()
    {
        foreach (GameObject child in Children)
        {
            BurstFrag burstFrag = child.GetComponent<BurstFrag>();
            burstFrag.Burst(minForce, maxForce);
        };
        Destroy(gameObject);
    }
}
