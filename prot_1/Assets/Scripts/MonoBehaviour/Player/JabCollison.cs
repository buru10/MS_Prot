using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JabCollison : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "BurstObject")
        {
            BurstVoxel burstVoxel = other.gameObject.GetComponent<BurstVoxel>();

            // オブジェクトの子供のフラグを変更する
            foreach (Transform child in other.transform)
            {
                if (child.tag == "Minimap")
                    continue;

                child.GetComponent<Garbage>().bBurst = true;
            }
            burstVoxel.Burst();
        }
    }
}
