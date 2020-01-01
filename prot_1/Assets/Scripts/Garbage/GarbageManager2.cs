using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageManager2 : MonoBehaviour
{
    // メンバ変数定義
    //生成したObjectを持っておくためのList
    public List<GameObject> Garbagelist = new List<GameObject>();
    //public List<GameObject> Garbagetype = new List<GameObject>();
    public GameObject ObjectPool;
    private GameObject cube;

    [SerializeField]int nCount;
    int TotalNum; 
    public int WarpSpawnNorma;
    public Warp warp;
    public CrashSpawner crashSpawner;

    public static int Percentage = 0;

    //public bool bNothing;
    //public bool bDrop;
    //public float fTime;
    //float SaveTime;

    // Start is called before the first frame update
    void Start()
    {
        Percentage = 0;

        foreach (Transform garbage in ObjectPool.transform)
        {
            SearchResource(garbage);
        }
        
        TotalNum = Garbagelist.Count;
        WarpSpawnNorma = 60;

        warp.gameObject.SetActive(false);
        crashSpawner.GetComponent<BoxCollider>().enabled = false;
        
    }

    void SearchResource(Transform Resource)
    {
        foreach (Transform child in Resource.transform)
        {
            if (child.tag == "BurstObject")
                SearchResource(child);

            if (child.tag == "wood"
                        || child.tag == "glass"
                        || child.tag == "plastic"
                        || child.tag == "metal")
                Garbagelist.Add(child.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            warp.gameObject.SetActive(true);
            crashSpawner.GetComponent<BoxCollider>().enabled = true;
        }

        //// 毎秒減らす
        //fTime -= Time.deltaTime;

        //// 0以下になったら
        //if (fTime <= 0.0f && bDrop && Garbagelist.Count <= nCount)
        //{
        //    // ランダムにポジションを決め、生成する
        //    Vector3 position = new Vector3(Random.Range(-20.0f, 20.0f), 0, Random.Range(-20.0f, 20.0f));
        //    cube = Instantiate(Garbagetype[Random.Range(0, Garbagetype.Count)], position, Quaternion.identity, transform);
        //    //cube.gameObject.GetComponent<BoxCollider>().enabled = false;

        //    foreach (Transform child in cube.transform)
        //    {
        //        if (child.tag == "Minimap")
        //            continue;
        //        if (child.tag == "Untagged")
        //            continue;

        //        Garbagelist.Add(child.gameObject);
        //    }

        //    //Garbagelist.Add(cube);


        //    bNothing = false;
        //    fTime = SaveTime;
        //    //cube.gameObject.GetComponent<Billboard>().CreateNumber = Garbagelist.Count-1;
        //}

        //if (Garbagelist.Count <= 0)
        //{
        //    bNothing = true;
        //}
    }

    public void SubCount()
    {
        nCount--;

        if(nCount <= WarpSpawnNorma)
        {
            warp.gameObject.SetActive(true);
            crashSpawner.GetComponent<BoxCollider>().enabled = true;
        }
    }

    public void CheckNorma()
    {
        Percentage = (int)((float)(TotalNum - Garbagelist.Count) / (float)TotalNum * 100.0f);
        if (Percentage >= WarpSpawnNorma)
        {
            warp.gameObject.SetActive(true);
            crashSpawner.GetComponent<BoxCollider>().enabled = true;
        }
    }

    public int GetPercentage()
    {
        return Percentage;
    }
}
