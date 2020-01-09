using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialUI : MonoBehaviour
{
    public bool b1_operation;
    public bool b2_operation;
    public bool b3_operation;
    public bool b4_operation;
    public bool b5_operation;
    public bool b6_operation;

    public GameObject[] tutorialtext_0 = new GameObject[2];
    public GameObject[] tutorialtext_1 = new GameObject[2];
    public GameObject[] tutorialtext_2 = new GameObject[2];
    public GameObject[] tutorialtext_3 = new GameObject[2];
    public GameObject[] tutorialtext_4 = new GameObject[1];
    public GameObject[] tutorialtext_5 = new GameObject[2];
    public GameObject[] tutorialtext_6 = new GameObject[2];

    int num;
    float textCounttimer;
    int textnum;
    public float textinterval = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        num = 0;
        for (int i = 0; i < tutorialtext_0.Length; i++)
        {
            tutorialtext_0[i].SetActive(false);
        }
        for (int i = 0; i < tutorialtext_1.Length; i++)
        {
            tutorialtext_1[i].SetActive(false);
        }
        for (int i = 0; i < tutorialtext_2.Length; i++)
        {
            tutorialtext_2[i].SetActive(false);
        }
        for (int i = 0; i < tutorialtext_3.Length; i++)
        {
            tutorialtext_3[i].SetActive(false);

        }
        for (int i = 0; i < tutorialtext_4.Length; i++)
        {
            tutorialtext_4[i].SetActive(false);
        }
        for (int i = 0; i < tutorialtext_5.Length; i++)
        {
            tutorialtext_5[i].SetActive(false);
        }
        for (int i = 0; i < tutorialtext_6.Length; i++)
        {
            tutorialtext_6[i].SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        switch (num)
        {
            case 0:
                tutorialtext_0[textnum].SetActive(true);
                textCounttimer += Time.deltaTime;

                if (textCounttimer >= textinterval && textnum != (tutorialtext_0.Length - 1))
                {
                    tutorialtext_0[textnum].SetActive(false);
                    textnum += 1;
                    textCounttimer = 0.0f;
                }

                if (b1_operation)
                {
                    for (int i = 0; i < tutorialtext_0.Length; i++)
                    {
                        tutorialtext_0[i].SetActive(false);
                    }
                    textCounttimer = 0.0f;
                    textnum = 0;
                    num = 1;

                }
                break;

            case 1:
                tutorialtext_1[textnum].SetActive(true);
                textCounttimer += Time.deltaTime;

                if (textCounttimer >= textinterval && textnum != (tutorialtext_1.Length - 1))
                {
                    tutorialtext_1[textnum].SetActive(false);
                    textnum += 1;
                    textCounttimer = 0.0f;
                }

                if (b2_operation)
                {
                    for (int i = 0; i < tutorialtext_1.Length; i++)
                    {
                        tutorialtext_1[i].SetActive(false);
                    }
                    textCounttimer = 0.0f;
                    textnum = 0;
                    num = 2;
                }
                break;

            case 2:
                tutorialtext_2[textnum].SetActive(true);
                textCounttimer += Time.deltaTime;

                if (textCounttimer >= textinterval && textnum != (tutorialtext_2.Length - 1))
                {
                    tutorialtext_2[textnum].SetActive(false);
                    textnum += 1;
                    textCounttimer = 0.0f;
                }

                if (b3_operation)
                {
                    for (int i = 0; i < tutorialtext_2.Length; i++)
                    {
                        tutorialtext_2[i].SetActive(false);
                    }
                    textCounttimer = 0.0f;
                    textnum = 0;
                    num = 3;
                }
                break;

            case 3:
                tutorialtext_3[textnum].SetActive(true);
                textCounttimer += Time.deltaTime;

                if (textCounttimer >= textinterval && textnum != (tutorialtext_3.Length - 1))
                {
                    tutorialtext_3[textnum].SetActive(false);
                    textnum += 1;
                    textCounttimer = 0.0f;
                }

                if (b4_operation)
                {
                    for (int i = 0; i < tutorialtext_3.Length; i++)
                    {
                        tutorialtext_3[i].SetActive(false);
                    }
                    textCounttimer = 0.0f;
                    textnum = 0;
                    num = 4;
                }
                break;

            case 4:
                tutorialtext_4[textnum].SetActive(true);
                textCounttimer += Time.deltaTime;

                if (textCounttimer >= textinterval && textnum != (tutorialtext_4.Length - 1))
                {
                    tutorialtext_4[textnum].SetActive(false);
                    textnum += 1;
                    textCounttimer = 0.0f;
                }

                if (b5_operation)
                {
                    for (int i = 0; i < tutorialtext_4.Length; i++)
                    {
                        tutorialtext_4[i].SetActive(false);
                    }
                    textCounttimer = 0.0f;
                    textnum = 0;
                    num = 5;
                }
                break;
            case 5:
                tutorialtext_5[textnum].SetActive(true);
                textCounttimer += Time.deltaTime;

                if (textCounttimer >= textinterval && textnum != (tutorialtext_5.Length - 1))
                {
                    tutorialtext_5[textnum].SetActive(false);
                    textnum += 1;
                    textCounttimer = 0.0f;
                }

                if (b6_operation)
                {
                    for (int i = 0; i < tutorialtext_5.Length; i++)
                    {
                        tutorialtext_5[i].SetActive(false);
                    }
                    textCounttimer = 0.0f;
                    textnum = 0;
                    num = 6;
                }
                break;
            case 6:
                tutorialtext_6[textnum].SetActive(true);
                textCounttimer += Time.deltaTime;

                if (textCounttimer >= textinterval && textnum != (tutorialtext_6.Length - 1))
                {
                    tutorialtext_6[textnum].SetActive(false);
                    textnum += 1;
                    textCounttimer = 0.0f;
                }

                break;
            default:
                break;
        }
    }
}
