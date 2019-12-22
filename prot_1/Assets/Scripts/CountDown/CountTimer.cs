using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountTimer : MonoBehaviour
{
    [SerializeField]
    float RemainTimeMax;
    public float remainTime;
    [SerializeField]
    StageStateManager ssm;


    // Start is called before the first frame update
    void Start()
    {
        remainTime = RemainTimeMax;
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

    }

    private void OnEnable()
    {
        remainTime = RemainTimeMax;
    }

    public void Reset()
    {
        remainTime = RemainTimeMax;
    }
}
