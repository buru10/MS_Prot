using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberTime : MonoBehaviour
{
    // メンバ変数定義
    public Sprite[] images;

    private int TimeCount = 671;  // 時間
    int[] TimeSave;               // 時間

    public float time;
    float timesave;

    // Start is called before the first frame update
    void Start()
    {
        timesave = time;

        // 時間
        TimeSave[0] = TimeCount / 600;       
        TimeSave[1] = TimeCount / 60 % 10;
        TimeSave[2] = TimeCount % 100 / 10;
        TimeSave[3] = TimeCount % 100 % 10;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
