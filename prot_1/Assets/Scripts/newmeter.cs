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
    public float Oneparam;//（paramobj/Resourcesmax）1パラメータ上げるのに必要なリソース数

    public bool blisaborn;

    public int onestock;//配列の長さに使う

    //public int onestock_metal;
    //public int onestock_plastic;
    //public int onestock_glass;
    //public int onestock_wood;
    public int old_metal;
    public int old_plastic;
    public int old_glass;
    public int old_wood;
    public int stockCount;
    public int memoryColor;

    public int debugnum;

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
        onestock = (int)Oneparam;
        if (onestock == 0)
        {
            onestock = 1;
        }

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
            + MeterCount[(int)Resources.glass] + MeterCount[(int)Resources.wood] + debugnum;

        //meter背景演出用
        if (old_metal != (int)MeterCount[(int)Resources.metal])
        {
            //onestock_metal += 1; 
            memoryColor = 0;
            old_metal = (int)MeterCount[(int)Resources.metal];
        }
        if(old_plastic != (int)MeterCount[(int)Resources.plastic])
        {
            //onestock_plastic += 1;]
            memoryColor = 1;
            old_plastic = (int)MeterCount[(int)Resources.plastic];
        }
        if(old_glass != (int)MeterCount[(int)Resources.glass])
        {
            //onestock_glass += 1;
            memoryColor = 2;
            old_glass = (int)MeterCount[(int)Resources.glass];

        }
        if (old_wood != (int)MeterCount[(int)Resources.wood])
        {
            //onestock_wood += 1;
            memoryColor = 3;
            old_wood = (int)MeterCount[(int)Resources.wood];
        }

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

            Player.GetComponent<RisaSpawner>().Spawn();
            Score.RisaNum++;

        }

        else//
        {
            for (int i = 0; i < (BundleResources / Oneparam); i++)
            {
                paramobj[i].SetActive(true);
                if (stockCount != i)
                {
                     stockCount = i;
                    //onestock_metal = 0;
                    //onestock_plastic = 0;
                    //onestock_glass = 0;
                    //onestock_wood = 0;
                   
                }
            }

        }


    }
}
