using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class RecoveryResources : MonoBehaviour
{
    // メンバ変数定義
    public Player Player;
    public GameObject Meter;
    public GameObject MainMeter;
    [SerializeField]
    private float direction; // 補完時間
    private float Savedirection; // 補完時間保存
    private float MainSavedirection; // 補完時間保存

    public Ease EaseType;

    // Start is called before the first frame update
    void Start()
    {
        if (!Player)
            Player = GameObject.Find("Player").GetComponent<Player>();
        if (!Meter)
            Meter = GameObject.Find("newmeter");
        // 子供の情報を受け取る
        foreach (Transform child in Meter.transform)
        {
            if ("Meterpos" == child.name)
                Meter = child.gameObject;
        }

        if (!MainMeter)
            MainMeter = GameObject.Find("newmeter");
        // 子供の情報を受け取る
        foreach (Transform child in MainMeter.transform)
        {
            if ("MainMeterpos" == child.name)
                MainMeter = child.gameObject;
        }

        direction = Random.Range(1, 4);
        Savedirection = direction;
        MainSavedirection = 1;

    }

    // Update is called once per frame
    void Update()
    {
        // 補完
        if (Savedirection >= 0)
        {
            gameObject.transform.DOMove(Meter.gameObject.transform.position, direction).SetEase(EaseType);
            gameObject.transform.DOScale(new Vector3(0.01f, 0.01f, 1.0f), direction).SetEase(EaseType);
            Savedirection -= Time.deltaTime;
        }
        else
        {
            if (MainSavedirection <= 0)
            {
                Player.SetResourcesPlus(gameObject.tag);
                Destroy(gameObject);
            }

            gameObject.transform.DOMove(MainMeter.gameObject.transform.position, 1).SetEase(EaseType);
            MainSavedirection -= Time.deltaTime;
        }
    }
}
