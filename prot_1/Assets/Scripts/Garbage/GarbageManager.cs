using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageManager : MonoBehaviour
{
    // メンバ変数定義
    //生成したObjectを持っておくためのList
    public List<GameObject> Garbagelist = new List<GameObject>();
    public List<GameObject> Garbagetype = new List<GameObject>();
    private GameObject billboard;

    public bool bNothing;
    public bool bDrop;
    public float fTime;
    public int CreateNumber;
    float SaveTime;


    // Start is called before the first frame update
    void Start()
    {
        if (Garbagelist?.Count > 0) bNothing = true;　// リストの中身が無いとき
        else bNothing = false;　

        SaveTime = fTime; // タイム保存

        bDrop = true;
    }

    // Update is called once per frame
    void Update()
    {
        // 毎秒減らす
        fTime -= Time.deltaTime;

        // 0以下になったら
        if (fTime <= 0.0f && bDrop)
        {
            // ランダムにポジションを決め、生成する
            Vector3 position = new Vector3(Random.Range(-20.0f, 20.0f), 0, Random.Range(-20.0f, 20.0f));
            billboard = Instantiate(Garbagetype[Random.Range(0, Garbagetype.Count)], position, Quaternion.identity, transform);
            billboard.gameObject.GetComponent<Billboard>().GetComponent<BoxCollider>().enabled = false;
            Garbagelist.Add(billboard);
            bNothing = false;
            fTime = SaveTime;
            billboard.gameObject.GetComponent<Billboard>().CreateNumber = Garbagelist.Count-1;
        }

        if (Garbagelist.Count <= 0)
        {
            bNothing = true;
        }
    }
}
