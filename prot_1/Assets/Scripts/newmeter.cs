using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public GameObject resourceiconobj;
    public GameObject resourceplusobj;
    public Sprite[] resourceicon = new Sprite[4];
    public bool bgeticon;
    public bool bmetermax;
    float bmetermaxtimer;
    int bmetermaxCount;
    public float resourceicontimer;

    public AudioClip meterCountsound;
    AudioSource audioSource;

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

        //Componentを取得
        audioSource = GetComponent<AudioSource>();
        bmetermax = false;
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

            resourceiconobj.GetComponent<Image>().sprite = resourceicon[0];
        }
        if (old_plastic != (int)MeterCount[(int)Resources.plastic])
        {
            //onestock_plastic += 1;]
            memoryColor = 1;
            old_plastic = (int)MeterCount[(int)Resources.plastic];
            resourceiconobj.GetComponent<Image>().sprite = resourceicon[1];
        }
        if (old_glass != (int)MeterCount[(int)Resources.glass])
        {
            //onestock_glass += 1;
            memoryColor = 2;
            old_glass = (int)MeterCount[(int)Resources.glass];
            resourceiconobj.GetComponent<Image>().sprite = resourceicon[2];

        }
        if (old_wood != (int)MeterCount[(int)Resources.wood])
        {
            //onestock_wood += 1;
            memoryColor = 3;
            old_wood = (int)MeterCount[(int)Resources.wood];
            resourceiconobj.GetComponent<Image>().sprite = resourceicon[3];
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

            stockCount = 0;
            bmetermax = true;

            bmetermaxCount = paramobj.Length - 1;
            Player.GetComponent<RisaSpawner>().Spawn();
            Score.RisaNum++;

        }

        else//
        {
            for (int i = 0; i < (BundleResources / Oneparam); i++)
            {
                paramobj[i].SetActive(true);

                if (stockCount < i)
                {
                    stockCount = i;
                    audioSource.PlayOneShot(meterCountsound);
                    bgeticon = true;
                    //onestock_metal = 0;
                    //onestock_plastic = 0;
                    //onestock_glass = 0;
                    //onestock_wood = 0;

                }
            }

        }
        if (bgeticon)
        {

            resourceicontimer += Time.deltaTime;
            if (resourceicontimer >= 1.0f)
            {
                resourceiconobj.SetActive(false);
                resourceplusobj.SetActive(false);
                resourceicontimer = 0.0f;
                bgeticon = false;
            }
            else
            {
                resourceiconobj.SetActive(true);
                resourceplusobj.SetActive(true);
            }

        }
        //メーターがmaxになった時段々減っていく処理

        if (bmetermax)
        {

            if (bmetermaxCount >= 0)
            {

                for (int j = paramobj.Length; j > bmetermaxCount; j--)
                {
                    paramobj[bmetermaxCount].transform.GetChild(0).GetComponent<UICornersGradient>().enabled = false;
                    paramobj[bmetermaxCount].SetActive(false);
                }
            }
            else
            {
                bmetermax = false;
            }

            bmetermaxtimer += Time.deltaTime;

            if (bmetermaxtimer >= 0.15f)
            {
                bmetermaxCount -= 1;
                bmetermaxtimer = 0;
            }


        }




    }
}
