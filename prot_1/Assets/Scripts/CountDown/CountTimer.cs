using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountTimer : MonoBehaviour
{
    [SerializeField]
    float RemainTimeMax;
    float remainTime;
    [SerializeField]
    StageStateManager ssm;

    public float Stage1Time;
    public float Stage2Time;
    public float Stage3Time;

    // Start is called before the first frame update
    void Start()
    {
        remainTime = RemainTimeMax;
    }

    // Update is called once per frame
    void Update()
    {
        float deltaTime = Time.deltaTime;

        remainTime -= deltaTime;
        GetComponent<Text>().text = remainTime.ToString("##0");

        if (remainTime < 0.0f)
            ssm.ChangeState(StageStateManager.StageState.Finish);

    }

    private void OnEnable()
    {
        remainTime = RemainTimeMax;
    }
}
