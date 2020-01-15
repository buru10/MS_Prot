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
    Image CountDown;

    [SerializeField]
    Canvas gamemain;

    [SerializeField]
    AIAnimation AIanim;
    //[SerializeField]
    //FadeRisa fade;

    [SerializeField] SceneChanger sceneChanger;

    public bool bTimeUp = false;

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
                Score.bStage1 = !Score.bStage1;
                AIanim.AIInStart();
                PlayerInputManager.SetEnabled(false);
                break;
            case StageState.Ready:
                CountDown.gameObject.SetActive(true);
                break;
            case StageState.Main:
                CountDown.gameObject.SetActive(false);
                PlayerInputManager.SetEnabled(true);
                gamemain.gameObject.SetActive(true);
                break;
            case StageState.ShutDown:
                Score.SaveRecycle(GarbageManager2.Percentage);
                PlayerInputManager.SetEnabled(false);
                gamemain.gameObject.SetActive(false);
                AIanim.AIOutStart();
                break;
            case StageState.Finish:
                if(bTimeUp)
                    sceneChanger.ChangeToResult();
                else
                    sceneChanger.ChangeToNext();
                break;
            default:
                break;
        }
    }
}
