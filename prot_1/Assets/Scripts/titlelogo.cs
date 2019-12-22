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
    float logotimer;
    float logointerval;
    int logoCount;
    public int movecount;
    Vector3[] logoscalmax;
    Vector3[] logoscalmin;
    // Start is called before the first frame update
    void Start()
    {
        num = 0;
        logotimer = 0;
        logointerval = 1.0f;
        logoCount = 0;
        movement = 20.0f;

        logoscalmin[0] = logo_Obj[0].GetComponent<RectTransform>().localScale;
        logoscalmax[0] = new Vector3(2.0f, 2.0f, 2.0f);
        logo_Obj[0].GetComponent<RectTransform>().localScale= logoscalmax[0];

        logopos_init = GetComponent<RectTransform>().localPosition;
        //Debug.Log(logopos_init);
        logopos_up = new Vector3(logopos_init.x, logopos_init.y + movement, logopos_init.z);
        logopos_down = new Vector3(logopos_init.x, logopos_init.y - movement, logopos_init.z);
        logopos_left = new Vector3(logopos_init.x - movement, logopos_init.y, logopos_init.z);
        logopos_right = new Vector3(logopos_init.x + movement, logopos_init.y, logopos_init.z);

        for (int i = 0; i < logo_Obj.Length; i++)
        {
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
                if (logotimer >= logointerval * logoCount && logotimer <= logointerval * (logoCount + 0.5f))
                {
                    logo_Obj[logoCount].SetActive(true);
                    
                }
                else if (logotimer >= logointerval * (logoCount + 1))
                {
                    logoCount += 1;
                }

                /*if (logotimer >= logointerval * logoCount && logotimer <= logointerval * (logoCount + 0.05f))
                { if (movecount == 0)
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
                    if (logoCount >= logo_Obj.Length)
                    {
                        ringObj.SetActive(true);
                        num = 1;
                    }
                }*/
                break;

            /*case 1:
                if ()
                {

                }
                break;*/

            default:
                break;
        }
        ringObj.transform.Rotate(new Vector3(0, 0, 2.0f));

    }
}
