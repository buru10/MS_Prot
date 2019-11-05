using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    // メンバ変数定義
    public bool bTarget; 
    public int CreateNumber; 

    // Start is called before the first frame update
    void Start()
    {
        bTarget = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 p = Camera.main.transform.position;
        p.y = transform.position.y;
        transform.LookAt(p);
    }
}
