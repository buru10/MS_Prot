using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisaSpawner : MonoBehaviour
{
    // メンバー変数定義
    public List<GameObject> risaspawner = new List<GameObject>();
    public GameObject risaspawnerSelect;

    public List<float> dis = new List<float>();

    // Start is called before the first frame update
    void Start()
    {
        risaspawnerSelect = null;
    }

    // Update is called once per frame
    void Update()
    {
        int nNum =0;

        // リストの中身を空にしておく
        dis.Clear();


        // 線分のリスト追加
        for (int i = 0; i < risaspawner.Count; i++)
        {
            Debug.DrawLine(transform.position, risaspawner[i].transform.position,new Color(255,0,0));

            Vector3 Apos = transform.position;
            Vector3 Bpos = risaspawner[i].transform.position;
            dis.Add(Vector3.Distance(Apos, Bpos));
        }

        // リストの中身比較
        for (int i = 0; i <= risaspawner.Count-1; i++)
        {
            if(Mathf.Min(dis[0], dis[i]) == dis[0])
            {
                continue;
            }
            else
            {
                nNum = i;
                dis[0] = dis[i];
            }
        }

        // 線分の近いものをセレクトする
        risaspawnerSelect = risaspawner[nNum];
    }
}
