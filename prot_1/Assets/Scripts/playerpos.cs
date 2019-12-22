using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerpos : MonoBehaviour
{

    public GameObject playerbj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // transformを取得
        Transform myTransform = this.transform;
        Transform playerTransform = playerbj.transform;
        
        myTransform.position = playerTransform.position;  // 座標を設定
    }
}
