using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountTimer : MonoBehaviour
{
    [SerializeField]
    float RemainTimeMax;
    public static float remainTime;
    [SerializeField]
    StageStateManager ssm;


    // Start is called before the first frame update
    void Start()
    {
        //remainTime = RemainTimeMax;
        string tenn = ":";
        float miliSec = remainTime - (int)remainTime;
        string text = remainTime.ToString("##0") + tenn + miliSec.ToString("f2").Substring(2, 2);
        GetComponent<Text>().text = text;
    }

    // Update is called once per frame
    void Update()
    {
        float deltaTime = Time.deltaTime;
        string tenn = ":";

        remainTime -= deltaTime;
        float miliSec = remainTime - (int)remainTime;
        string text = remainTime.ToString("##0") + tenn + miliSec.ToString("f2").Substring(2, 2);
        GetComponent<Text>().text = text;

        if (remainTime < 0.0f)
            ssm.ChangeState(StageStateManager.StageState.ShutDown);


        //// 審査
        //if(Input.GetKeyDown(KeyCode.A))
        //{
        //    remainTime = 600.0f;
        //}

    }

    //private void OnEnable()
    //{
    //    remainTime = RemainTimeMax;
    //}

    public void Reset()
    {
        remainTime = RemainTimeMax;
    }
}
