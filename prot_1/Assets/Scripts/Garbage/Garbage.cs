using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garbage : MonoBehaviour
{
    // メンバ変数定義
    public bool bTarget;
    public bool bBurst;

    private float deleteTime;
    private GarbageManager garbageManager;

    // Start is called before the first frame update
    void Start()
    {
        if (!garbageManager)
            garbageManager = GameObject.Find("GarbageManager").GetComponent<GarbageManager>();
        bTarget = false;
        bBurst = false;
        //GetComponent<BoxCollider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
