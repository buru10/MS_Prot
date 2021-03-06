﻿using System.Collections;
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

    public State state = FadeRisa.State.FadeIn;

    private bool bEndFadeIn = false;
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
        switch(state)
        {
            case State.FadeIn:
                posX += speed;
                if (rect.localPosition.x >= BorderposXIn)
                {
                    posX = -BorderposXIn;
                    bEndFadeIn = true;
                    state = State.None;
                }
                break;
            case State.FadeOut:
                posX += speed;
                if (rect.localPosition.x >= BorderposXOut)
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
    public bool getEndFlagIn()
    {
        return bEndFadeIn;
    }

    public void StartFade()
    {
        state = State.FadeOut;
        posX = -BorderposXIn;
    }
}
