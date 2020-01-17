using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countdownmove : MonoBehaviour
{

    //321
    public GameObject countdownobj;
    public Vector3 Startpos;
    public Vector3 Endpos;
    float Counttimer;
    float alpha;

    //go
    public GameObject goobj;
    public Vector3 goSpos;
    public Vector3 goMpos;
    public Vector3 goLpos;
    float LStimer;
    float SMtimer;
    float goalpha;
    float timer;

    public GameObject goalphaobj;
    float GoalalphaMLtimer;

    AudioSource audioSource;
    public AudioClip se_321sound;
    public AudioClip se_gosound;

    // Start is called before the first frame update
    void Start()
    {
        countdownobj.GetComponent<RectTransform>().localPosition = Startpos;
        alpha = 1.0f;
        goobj.SetActive(false);
        goalphaobj.SetActive(false);

        //Componentを取得
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (countdownobj.gameObject.activeSelf)
        {
            if (Counttimer == 0.0f)
            {
                audioSource.PlayOneShot(se_321sound);
            }
            timer += Time.deltaTime;
            Counttimer += Time.deltaTime;
            if (Counttimer < 0.8f)
            {
                countdownobj.GetComponent<RectTransform>().localPosition = Vector3.Lerp(Startpos, Endpos, (Counttimer * 2));
            }
            else if (Counttimer >= 0.8f && Counttimer < 1.0f)
            {
                alpha -= (Time.deltaTime * 5);
            }
            countdownobj.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, alpha);
            if (Counttimer >= 1.0f)
            {
                Counttimer = 0.0f;
                alpha = 1.0f;
            }

        }

        if (countdownobj.gameObject.activeSelf == false && timer >= 2.9f)
        {
            goobj.SetActive(true);

            if(LStimer==0.0f)
            {
                audioSource.PlayOneShot(se_gosound);
            }
            LStimer += (Time.deltaTime * 3);
            if (LStimer <= 1.0f)
            {
                goobj.GetComponent<RectTransform>().localScale = Vector3.Lerp(goLpos, goSpos, LStimer);
            }
            if (LStimer > 1.0f)
            {
                SMtimer += (Time.deltaTime * 6);
                goobj.GetComponent<RectTransform>().localScale = Vector3.Lerp(goSpos, goMpos, SMtimer);
            }

        }

        if (SMtimer >= 1.0f)
        {
            goalphaobj.SetActive(true);
            GoalalphaMLtimer += (Time.deltaTime * 4);
            goalphaobj.GetComponent<RectTransform>().localScale = Vector3.Lerp(goMpos, goLpos, GoalalphaMLtimer);
            if (GoalalphaMLtimer >= 0.7f)
            {
                goalpha -= Time.deltaTime * 4;
                goalphaobj.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, goalpha);
            }
            goobj.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1 - (GoalalphaMLtimer / 2));
            
        }
    }
}
