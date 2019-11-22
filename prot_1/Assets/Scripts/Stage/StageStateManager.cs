using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageStateManager : MonoBehaviour
{
    [SerializeField]
    Canvas GaugeCanvas;
    [SerializeField]
    Canvas MiniMap;

    enum StageState
    {
        Ready,
        Main,
        Finish
    };

    StageState stageState;

    // Start is called before the first frame update
    void Start()
    {
        stageState = StageState.Ready;
    }

    // Update is called once per frame
    void Update()
    {
        switch(stageState)
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
}
