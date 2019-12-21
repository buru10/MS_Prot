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
    [SerializeField]
    AIAnimation AIanim;
    [SerializeField]
    Fade fade;

    public enum StageState
    {
        Boot,
        Ready,
        Main,
        ShutDown,
        Finish
    };

    [SerializeField]
    StageState stageState;

    // Start is called before the first frame update
    void Start()
    {
        ChangeState(StageState.Boot);
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
            case StageState.Boot:
                AIanim.AIInStart();
                PlayerInputManager.SetEnabled(false);
                break;
            case StageState.Ready:
                //CountDownText.gameObject.SetActive(true);
                CountDown.gameObject.SetActive(true);
                break;
            case StageState.Main:
                CountDown.gameObject.SetActive(false);
                PlayerInputManager.SetEnabled(true);
                //TimerText.gameObject.SetActive(true);
                break;
            case StageState.ShutDown:
                PlayerInputManager.SetEnabled(false);
                TimerText.gameObject.SetActive(false);
                AIanim.AIOutStart();
                break;
            case StageState.Finish:
                fade.StartFade();
                break;
            default:
                break;
        }
    }
}
