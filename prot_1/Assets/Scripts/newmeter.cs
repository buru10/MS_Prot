using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newmeter : MonoBehaviour
{
    public float Resourcesmax;

    public Player Player;

    public GameObject[] paramobj;//30個あるよ

    //[HideInInspector]
    public float[] MeterCount;//Playerから貰った値を入れる
    float BundleResources;//MeterCountをまとめる
    float Oneparam;//（paramobj/Resourcesmax）1パラメータ上げるのに必要なリソース数
    
    public bool blisaborn;

    enum Resources
    {
        metal = 0,
        plastic,
        glass,
        wood,
        Resourcesmax

    };
    // Start is called before the first frame update
    void Start()
    {

        MeterCount = new float[5];

        for (int i = 0; i < paramobj.Length; i++)
        {
            paramobj[i].SetActive(false);
        }

        Oneparam = Resourcesmax / paramobj.Length;

        blisaborn = false;
    }

    // Update is called once per frame
    void Update()
    {
        //playerからゲットした資源の情報を貰う
        MeterCount[(int)Resources.metal] = Player.GetResources("metal");
        MeterCount[(int)Resources.plastic] = Player.GetResources("plastic");
        MeterCount[(int)Resources.glass] = Player.GetResources("glass");
        MeterCount[(int)Resources.wood] = Player.GetResources("wood");

        //BundleResourcesに全部まとめる
        BundleResources = MeterCount[(int)Resources.metal] + MeterCount[(int)Resources.plastic]
            + MeterCount[(int)Resources.glass] + MeterCount[(int)Resources.wood];

        //meterが貯まったら値リセット
        if (BundleResources >= Resourcesmax)
        {
            //リサ生成フラグをtrueにする
            blisaborn = true;
            //値を初期化
            BundleResources = 0;
            //メーター初期化
            Player.SetResources("metal", 0);
            Player.SetResources("wood", 0);
            Player.SetResources("paper", 0);
            Player.SetResources("plastic", 0);
            Player.SetResources("glass", 0);

            for (int i = 0; i < paramobj.Length; i++)
            {
                paramobj[i].SetActive(false);
            }
        }

        else//
        {
            for (int i = 0; i < (BundleResources / Oneparam); i++)
            {
                paramobj[i].SetActive(true);
            }
        }


    }
}
