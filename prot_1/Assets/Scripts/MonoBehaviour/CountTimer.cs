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

    // Start is called before the first frame update
    void Start()
    {
        remainTime = RemainTimeMax;
    }

    // Update is called once per frame
    void Update()
    {
        remainTime -= Time.deltaTime;
        GetComponent<Text>().text = remainTime.ToString("##0");

        if (remainTime < 0.0f)
            ssm.ChangeState(StageStateManager.StageState.Finish);

    }

    private void OnEnable()
    {
        remainTime = RemainTimeMax;
    }
}
