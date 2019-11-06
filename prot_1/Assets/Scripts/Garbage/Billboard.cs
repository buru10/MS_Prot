using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    // メンバ変数定義
    public bool bTarget; 
    public int CreateNumber;

    private float deleteTime;

    // Start is called before the first frame update
    void Start()
    {
        bTarget = false;
        deleteTime = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // ビルボード処理
        Vector3 p = Camera.main.transform.position;
        p.y = transform.position.y;
        transform.LookAt(p);


        deleteTime -= Time.deltaTime;

        // 時間経過で消す
        if (deleteTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
