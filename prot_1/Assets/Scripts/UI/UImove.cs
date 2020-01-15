using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UImove : MonoBehaviour
{
    // メンバ変数定義
    private RectTransform rect;

    [SerializeField]
    private Vector3 StartPosition; // 補完開始座標
    [SerializeField]
    private Vector3 EndPosition;   // 補完終了座標
    [SerializeField]
    private Vector3 StartPosition2; // 補完開始座標2
    [SerializeField]
    private Vector3 EndPosition2;   // 補完終了座標2
    [SerializeField]
    private float direction; // 補完時間
    [SerializeField]
    private float delay;    // 遅らせる時間
    [SerializeField]
    private float direction2; // 補完時間2
    [SerializeField]
    private float delay2;    // 遅らせる時間2

    private float Sumtime;    // 合計補完時間
    private float Sumtime2;    // 合計補完時間2

    public Ease EaseType;
    public bool bfadeentry; // フェードがいるかどうか
    public bool bOneWave;   // 最初だけでよいか
    private bool bTrigger;   // 最初の補完終了フラグ
    private bool bTrigger2;  // 最後の補完終了フラグ
    public FadeRisa fadeRisa;


    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        rect.localPosition = StartPosition;

        // 初期化
        Sumtime = direction + delay;
        Sumtime2 = direction2 + delay2;

        bTrigger = false;
        bTrigger2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        // フェード終了時に実行するかどうか
        if (!bfadeentry)
        {
            // フェードイン終了時
            if (fadeRisa.getEndFlagIn())
            {
                if (Sumtime > 0)
                {
                    // 補完
                    rect.DOLocalMove(EndPosition, direction).SetEase(EaseType).SetDelay(delay);

                    Sumtime -= Time.deltaTime;
                    if (Sumtime > 0) bTrigger = true;
                }
                else
                {
                    if (bOneWave)
                    {
                        // 補完
                        rect.DOLocalMove(EndPosition2, direction2).SetEase(EaseType).SetDelay(delay2);

                        Sumtime2 -= Time.deltaTime;
                        if (Sumtime2 > 0) bTrigger2 = true;
                    }
                }
            }
        }
        else
        {
            if (Sumtime > 0)
            {
                // 補完
                rect.DOLocalMove(EndPosition, direction).SetEase(EaseType).SetDelay(delay);

                Sumtime -= Time.deltaTime;
                if (Sumtime > 0) bTrigger = true;
            }
            else
            {
                if (bOneWave)
                {
                    // 補完
                    rect.DOLocalMove(EndPosition2, direction2).SetEase(EaseType).SetDelay(delay2);

                    Sumtime2 -= Time.deltaTime;
                    if (Sumtime2 > 0) bTrigger2 = true;
                }
            }
        }
    }

    public bool GetTrigger()
    {
        return bTrigger;
    }
    public bool GetTrigger2()
    {
        return bTrigger2;
    }
}
