using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garbage : MonoBehaviour
{
    // メンバ変数定義
    public bool bTarget;
    public bool bBurst;

    private float deleteTime;
    private GarbageManager2 garbageManager;

    // Start is called before the first frame update
    void Start()
    {
        if (!garbageManager)
            garbageManager = GameObject.Find("GarbageManager2").GetComponent<GarbageManager2>();
        bTarget = false;
        bBurst = false;
        //GetComponent<BoxCollider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
