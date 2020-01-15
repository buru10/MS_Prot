using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisaSpawnCount : MonoBehaviour
{
    // メンバ変数定義
    public GameObject risaObj;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i =0;i<Score.RisaNum;i++)
        {
            Instantiate(risaObj, transform.position, Quaternion.identity, transform.root);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
