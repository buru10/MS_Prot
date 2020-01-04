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

    public Ease EaseType;
    public FadeRisa fadeRisa;


    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        rect.localPosition = StartPosition;
    }

    // Update is called once per frame
    void Update()
    {
        // フェードイン終了時
        if (fadeRisa.getEndFlagIn())
        {
            rect.DOLocalMove(EndPosition, direction).SetEase(EaseType).SetDelay(delay);
        }
    }
}
