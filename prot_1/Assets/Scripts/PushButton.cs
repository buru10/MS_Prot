using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PushButton : MonoBehaviour
{
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
    public GameObject RisaikuruAIManager;

    // Start is called before the first frame update
    void Start()
    {
        InitTime = 0.5f;
        TimeCount = InitTime;
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

        if (Input.GetKeyDown(KeyCode.Return))
        {
            this.gameObject.SetActive(false);
            //メーター初期化
            Player.SetResources("metal", 0);
            Player.SetResources("paper", 0);
            Player.SetResources("plastic", 0);
            Player.SetResources("glass", 0);

            // 指定した分だけ生成する
            for (int i = 0; i < CreateNum; i++)
            {
                Instantiate(RisaikuruAI, new Vector3(0.0f, 5.0f, 0.0f), Quaternion.identity,RisaikuruAIManager.transform);
            }
                //meter.MeterCount = 0;
        }

    }
}
