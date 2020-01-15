using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shovel : MonoBehaviour
{
    private List<BurstResource> colList = new List<BurstResource>();

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
        if (other.tag == "BurstObject")
        {
            colList.Add(other.GetComponent<BurstResource>());
        }
    }
    
    public void ShovelOff()
    {
        for(int i = colList.Count - 1; i >= 0; i--)
        {
            colList[i].bPushed = false;
            //colList[i].GetComponent<Rigidbody>().isKinematic = true;
        }
        
        colList.Clear();
    }
}
