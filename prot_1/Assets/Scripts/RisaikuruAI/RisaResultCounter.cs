using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisaResultCounter : MonoBehaviour
{
    public GameObject[] risa;

    // Start is called before the first frame update
    void Start()
    {
        // 配列に子供を入れ込んでから消す
        int i = 0;
        //GameObject[] risa = new GameObject[gameObject.transform.childCount]; // 子供の数分初期化
        foreach (Transform child in transform)
        {
            risa[i] = child.gameObject;
            risa[i].SetActive(false);
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i=0; i< Score.RisaNum;i++)
        {
            risa[i].SetActive(true);
        }
    }
}
