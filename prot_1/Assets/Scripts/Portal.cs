using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    // メンバ変数定義
    private bool bWarp;

    // Start is called before the first frame update
    void Start()
    {
        bWarp = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlayerCharactor")
        {
            bWarp = true;
        }
    }

    public bool GetWarp()
    {
        return bWarp;
    }
}
