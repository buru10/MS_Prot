using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; //System.IO.FileInfo, System.IO.StreamReader, System.IO.StreamWriter

public class JabCollison : MonoBehaviour
{
    public GameObject ParticleObj;

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
            Instantiate(ParticleObj, transform.position, Quaternion.identity);

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
