using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeRisa : MonoBehaviour
{
    public enum State
    {
        None,
        FadeIn,
        FadeOut
    };

    [SerializeField]
    float speed = 0.01f;        // リサの速さ

    float posX;                 // ポジションx
    public float BorderposXOut;                 // 境界ポジションx
    public float BorderposXIn;                 // 境界ポジションx

    State state = FadeRisa.State.FadeIn;

    bool bEndFadeOut = false;

    RectTransform rect;

    // Start is called before the first frame update
    void Start()
    {
        
        rect = GetComponent<RectTransform>();
        rect.localPosition = new Vector3(BorderposXOut,0.0f,0.0f);
        posX = rect.localPosition.x;
    }

    // Update is called once per frame
    void Update()
    {
        // デバッグ用
        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            state = State.FadeOut;
            posX = -5000.0f;
        }

        switch(state)
        {
            case State.FadeIn:
                posX += speed;
                if (posX >= BorderposXIn)
                {
                    posX = -5000.0f;
                    state = State.None;
                }
                break;
            case State.FadeOut:
                posX += speed;
                if (posX >= BorderposXOut)
                {
                    posX = BorderposXOut;
                    bEndFadeOut = true;
                    state = State.None;
                }
                break;
            case State.None:
                break;
        }

        rect.localPosition = new Vector3(posX,0.0f,0.0f);
    }

    public bool getEndFlag()
    {
        return bEndFadeOut;
    }

    public void StartFade()
    {
        state = State.FadeOut;
        posX = -5000.0f;
    }
}
