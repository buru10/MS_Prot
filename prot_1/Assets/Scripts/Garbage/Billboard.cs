using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    // メンバ変数定義
    public bool bTarget; 
    public int CreateNumber;

    private float deleteTime;
    private GarbageManager garbageManager;

    // Start is called before the first frame update
    void Start()
    {
        if (!garbageManager)
            garbageManager = GameObject.Find("GarbageManager").GetComponent<GarbageManager>();
        bTarget = false;
        deleteTime = 100.0f;
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
            garbageManager.Garbagelist.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}
