using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisaikuruAIManager : MonoBehaviour
{
    // メンバ変数定義
    private int CreateNumber;
    private int nCnt;

    public static int CountRisa;

    // Start is called before the first frame update
    void Awake()
    {
        // 解放しないようにする
        DontDestroyOnLoad(this);

        // 変数初期化
        CountRisa = 0;
    }

    public void AddRisa()
    {
        CountRisa++;
    }

    public int GetRisaCount()
    {
        return CountRisa;
    }
}
