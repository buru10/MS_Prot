using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WipeText : MonoBehaviour
{
    private Image wipetext;
    [SerializeField]
    float speed = -0.01f;
    float alpha = 1.0f;
    bool bPlus = false;

    // Start is called before the first frame update
    void Start()
    {
        wipetext = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        alpha += speed;

        if(bPlus)
        {
            if(alpha > 1.0f)
            {
                alpha = 1.0f;
                bPlus = !bPlus;
                speed *= -1;
            }
        }
        else
        {
            if (alpha < 0.5f)
            {
                alpha = 0.5f;
                bPlus = !bPlus;
                speed *= -1;
            }
        }

        wipetext.color = new Color(wipetext.color.r, wipetext.color.g, wipetext.color.b, alpha);
    }
}
