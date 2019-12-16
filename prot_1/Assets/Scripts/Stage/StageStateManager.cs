using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageStateManager : MonoBehaviour
{
    [SerializeField]
    Canvas GaugeCanvas;
    [SerializeField]
    Canvas MiniMap;
    [SerializeField]
    Text CountDownText;
    [SerializeField]
    Image CountDown;
    [SerializeField]
    Text TimerText;

    public enum StageState
    {
        Ready,
        Main,
        Finish
    };

    StageState stageState;

    // Start is called before the first frame update
    void Start()
    {
        ChangeState(StageState.Ready);
    }

    // Update is called once per frame
    void Update()
    {
        switch (stageState)
        {
            case StageState.Ready:
                UpdateReady();
                break;
            case StageState.Main:
                UpdateMain();
                break;
            case StageState.Finish:
                UpdateFinish();
                break;
            default:
                break;
        }
    }

    void UpdateReady()
    {

    }

    void UpdateMain()
    {

    }

    void UpdateFinish()
    {

    }

    public void ChangeState(StageState set)
    {
        stageState = set;

        switch (stageState)
        {
            case StageState.Ready:
                //CountDownText.gameObject.SetActive(true);
                CountDown.gameObject.SetActive(true);
                PlayerInputManager.SetEnabled(false);
                break;
            case StageState.Main:
                CountDown.gameObject.SetActive(false);
                PlayerInputManager.SetEnabled(true);
                //TimerText.gameObject.SetActive(true);
                break;
            case StageState.Finish:
                TimerText.gameObject.SetActive(false);
                PlayerInputManager.SetEnabled(false);
                break;
            default:
                break;
        }
    }
}
