using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class titlelogo : MonoBehaviour
{
    public GameObject plate_ShadeObj;
    public GameObject plateObj;
    public GameObject ringObj;
    public GameObject[] logo_Obj = new GameObject[7];
    public Sprite[] plate = new Sprite[2];
    public Sprite[] plateshade = new Sprite[2];

    Vector3 logopos_init;
    Vector3 logopos_up;
    Vector3 logopos_down;
    Vector3 logopos_left;
    Vector3 logopos_right;
    public float movement;

    int num;
    public float logotimer;
    float logointerval;
    int logoCount;
    public int movecount;
    Vector3[] logoscalmax;
    Vector3[] logoscalmin;

    public float[] text_scale;
    // Start is called before the first frame update
    void Start()
    {
        num = 0;
        logotimer = 0;
        logointerval = 1.0f;
        logoCount = 0;
        movement = 20.0f;

        logoscalmax = new Vector3[logo_Obj.Length];
        logoscalmin = new Vector3[logo_Obj.Length];
        text_scale = new float[logo_Obj.Length];


        logopos_init = GetComponent<RectTransform>().localPosition;

        logopos_up = new Vector3(logopos_init.x, logopos_init.y + movement, logopos_init.z);
        logopos_down = new Vector3(logopos_init.x, logopos_init.y - movement, logopos_init.z);
        logopos_left = new Vector3(logopos_init.x - movement, logopos_init.y, logopos_init.z);
        logopos_right = new Vector3(logopos_init.x + movement, logopos_init.y, logopos_init.z);

        for (int i = 0; i < logo_Obj.Length; i++)
        {
            logoscalmax[i] = new Vector3(2.0f, 2.0f, 2.0f);
            logoscalmin[i] = logo_Obj[i].GetComponent<RectTransform>().localScale;
            logo_Obj[i].GetComponent<RectTransform>().localScale = logoscalmax[i];

            logo_Obj[i].SetActive(false);

        }
        ringObj.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {


        switch (num)
        {
            case 0:
                logotimer += Time.deltaTime;

                //logotimer >=0.0f&&logotimer <=0.5//1.0&&1.5
                if (logotimer >= logointerval * logoCount)
                {
                    logo_Obj[logoCount].SetActive(true);
                    logo_Obj[logoCount].GetComponent<RectTransform>().localScale = Vector3.Lerp(logoscalmax[logoCount], logoscalmin[logoCount], text_scale[logoCount]);
                    text_scale[logoCount] += Time.deltaTime;

                }

                //logotimer >=1.0fになったら次の文字を出す
                if (logotimer >= logointerval * (logoCount + 1))
                {
                    logoCount += 1;
                }

                //logotimer >=0.0f&&logotimer <=0.05
                /*  if (logotimer >= logointerval * (logoCount + 0.5f) && logotimer <= logointerval * (logoCount + 0.55f))
                  {
                      if (movecount == 0)
                      {
                          GetComponent<RectTransform>().localPosition = logopos_up;
                          movecount = 1;
                      }
                      else if (movecount == 1)
                      {
                          GetComponent<RectTransform>().localPosition = logopos_down;
                          movecount = 2;
                      }
                      else if (movecount == 2)
                      {
                          GetComponent<RectTransform>().localPosition = logopos_left;
                          movecount = 3;
                      }
                      else if (movecount == 3)
                      {
                          GetComponent<RectTransform>().localPosition = logopos_right;
                          movecount = 0;
                      }
                  }*/
                //文字が全部出たらリングを出す
                if (logoCount >= logo_Obj.Length)
                {
                    ringObj.SetActive(true);
                    num = 1;
                }

                break;

            default:
                break;
        }
        ringObj.transform.Rotate(new Vector3(0, 0, 2.0f));

    }
}
