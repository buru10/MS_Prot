using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class newmetermaxmove : MonoBehaviour
{
    public GameObject risaobj;
    public GameObject risaBigobj;
    public Vector3 risaSpos;
    public Vector3 risaMpos;
    public Vector3 risaLpos;
    public Vector3 risaBigStartpos;

    float MLtimer;
    float LStimer;
    float SMtimer;

    float MLtimerbig;
    float bigalpha = 1.0f;

    public newmeter newmeter;
    bool moveon=false;

    AudioSource audioSource;
    public AudioClip meterCountsound;


    // Start is called before the first frame update
    void Start()
    {
        risaobj.GetComponent<RectTransform>().localScale = risaMpos;
        risaBigobj.SetActive(false);

        //Componentを取得
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(newmeter.bmetermax)
        {
            moveon = true;
            
        }
        if (moveon)
        {
            if (LStimer == 0.0f)
            {
                audioSource.PlayOneShot(meterCountsound);
            }
            if (LStimer >= 0.0f && LStimer <= 1.0f)
            {
                LStimer += (Time.deltaTime * 3);

                risaobj.GetComponent<RectTransform>().localScale = Vector3.Lerp(risaLpos, risaSpos, LStimer);
            }
            if (LStimer > 1.0f)
            {
                SMtimer += (Time.deltaTime * 3);
                risaobj.GetComponent<RectTransform>().localScale = Vector3.Lerp(risaSpos, risaMpos, SMtimer);
            }
            if (SMtimer >= 1.0f)
            {
                risaBigobj.SetActive(true);
                MLtimerbig += (Time.deltaTime * 3);
                risaBigobj.GetComponent<RectTransform>().localScale = Vector3.Lerp(risaMpos, risaBigStartpos, MLtimerbig);
                if (MLtimerbig >= 0.7f)
                {
                    bigalpha -= Time.deltaTime * 4;
                    risaBigobj.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, bigalpha);
                    if(bigalpha<=0.0f)
                    {
                        moveon = false;
                    }
                }
            }
        }
        else
        {
            MLtimer=0.0f;
            LStimer = 0.0f;
            SMtimer = 0.0f;
            MLtimerbig = 0.0f;
            bigalpha = 1.0f;
            risaBigobj.GetComponent<RectTransform>().localScale = risaMpos;
            risaBigobj.SetActive(false);
        }
    }
}
