using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class titlelogo : MonoBehaviour
{
    public GameObject plate_ShadeObj;
    public GameObject plateObj;
    public GameObject ringObj;
    public GameObject[] logo_Obj=new GameObject[7];
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
    // Start is called before the first frame update
    void Start()
    {
        num = 0;
        logotimer = 0;
        logopos_init = this.transform.position;
        Debug.Log(logopos_init);
       // logopos_up = new Vector3(logopos_init.x,logopos_init.y,logopos_init.z);
        logopos_down = this.transform.position;
        logopos_left = this.transform.position;
        logopos_right = this.transform.position;

        for (int i=0; i<logo_Obj.Length;i++)
        {
            logo_Obj[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {


        switch (num)
        {
            case 0:
                logotimer += Time.deltaTime;
                if(logotimer>=1.0f)
                {
                    logo_Obj[0].SetActive(true);
                }
                else if(logotimer >= 2.0f)
                {
                    logo_Obj[1].SetActive(true);
                }

                break;

            default:
                break;
        }
        ringObj.transform.Rotate(new Vector3(0, 0, 2.0f));

    }
}
