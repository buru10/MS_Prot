using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    // メンバ変数定義
    public GameObject gameObject;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // オブジェクトの方を向く
        transform.LookAt(gameObject.transform);
    }
}
