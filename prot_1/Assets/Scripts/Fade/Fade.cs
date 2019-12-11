using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public enum State
    {
        None,
        FadeIn,
        FadeOut
    };

    [SerializeField]
    float speed = 0.01f;        // 透明化の速さ
    float alpha;                // A値を操作するための変数
    float red, green, blue;     // RGBを操作するための変数

    [SerializeField]
    Image image;

    State state = Fade.State.FadeIn;

    // Start is called before the first frame update
    void Start()
    {
        ////Panelの色を取得
        red = image.color.r;
        green = image.color.g;
        blue = image.color.b;

        alpha = 1.0f;

        image.color = new Color(red, green, blue, alpha);
    }

    // Update is called once per frame
    void Update()
    {
        // デバッグ用
        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            state = State.FadeOut;
            alpha = 0.0f;
        }

        switch(state)
        {
            case State.FadeIn:
                alpha -= speed;
                if (alpha <= 0.0f)
                {
                    alpha = 0.0f;
                    state = State.None;
                }
                break;
            case State.FadeOut:
                alpha += speed;
                if (alpha >= 1.0f)
                {
                    alpha = 1.0f;
                    state = State.FadeIn;
                }
                break;
            case State.None:
                break;
        }

        image.color = new Color(red, green, blue, alpha);
    }
}
