using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisaSpawnCount : MonoBehaviour
{
    // メンバ変数定義
    private RisaikuruAIManager aIManager;
    public GameObject risaObj;
    

    // Start is called before the first frame update
    void Start()
    {
        if(!aIManager)
            aIManager= GameObject.Find("RisaikuruAIManager").GetComponent<RisaikuruAIManager>();

        for(int i =0;i<aIManager.GetRisaCount();i++)
        {
            Instantiate(risaObj, transform.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
