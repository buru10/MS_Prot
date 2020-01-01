using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PushButton : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject ControllerObj;

    public Sprite ControllerImagetrue;
    public Sprite ControllerImagefalse;

    float InitTime;
    float TimeCount;

    public meter meter;
    public Player Player;

    [Range(1, 10)]
    public int CreateNum;
    public GameObject RisaikuruAI;
    public GameObject RisaikuruAIObject;

    float TriggerPressCount;               // トリガーを押している時間
    public float TriggerPressTime = 1.0f;  // この時間トリガーを長押しするとロボ生成
    public GameObject[] metereffect;
    public GameObject[] back;
    // Start is called before the first frame update
    void Start()
    {

        InitTime = 0.5f;
        TimeCount = InitTime;
        TriggerPressCount = 0.0f;

        if (!Player)
            Player = GameObject.Find("Player").GetComponent<Player>();

    }

    // Update is called once per frame
    void Update()
    {
        TimeCount -= Time.deltaTime;
        if (TimeCount <= 0)
        {
            ControllerObj.GetComponent<Image>().sprite = ControllerImagefalse;
            TimeCount = InitTime;
        }
        else if (TimeCount <= InitTime / 2)
        {
            ControllerObj.GetComponent<Image>().sprite = ControllerImagetrue;
        }

        //if (Input.GetKeyDown(KeyCode.Return) || (Input.GetAxis("L_Trigger") > 0 && Input.GetAxis("R_Trigger") > 0) )
        {
            TriggerPressCount += Time.deltaTime;
#if false
            if (TriggerPressCount > TriggerPressTime)
#endif

            CreateRobot();
        }
        //else
        {

        }

    }

    void CreateRobot()
    {
        for (int i = 0; i < 4; i++)
        {
            back[i].GetComponent<Image>().color = new Color(0, 0, 0, 1);
            metereffect[i].SetActive(false);
        }
            this.gameObject.SetActive(false);
        //メーター初期化
        Player.SetResources("metal", 0);
        Player.SetResources("wood", 0);
        Player.SetResources("paper", 0);
        Player.SetResources("plastic", 0);
        Player.SetResources("glass", 0);

        // 指定した分だけ生成する
        for (int i = 0; i < CreateNum; i++)
        {
            //Instantiate(RisaikuruAI, Player.GetComponent<RisaSpawner>().risaspawnerSelect.transform.position, Quaternion.identity, RisaikuruAIObject.transform);
            Player.GetComponent<RisaSpawner>().Spawn();
            Score.RisaNum++;
        }
        //meter.MeterCount = 0;
    }
}
