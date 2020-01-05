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
    private float direction; // 補完時間
    [SerializeField]
    private float delay;    // 遅らせる時間
    private float Sumtime;    // 合計補完時間

    public Ease EaseType;
    public bool bfadeentry; // フェードがいるかどうか
    public FadeRisa fadeRisa;


    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        rect.localPosition = StartPosition;

        // 初期化
        Sumtime = direction + delay;
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
                // 補完
                rect.DOLocalMove(EndPosition, direction).SetEase(EaseType).SetDelay(delay);

                Sumtime -= Time.deltaTime;
                if (Sumtime <= 0) GetComponent<UImove>().enabled = false;
            }
        }
        else
        {
            // 補完
            rect.DOLocalMove(EndPosition, direction).SetEase(EaseType).SetDelay(delay);

            Sumtime -= Time.deltaTime;
            if (Sumtime <= 0) GetComponent<UImove>().enabled = false;
        }
    }
}
