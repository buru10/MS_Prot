using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class titlelogo : MonoBehaviour
{
    public GameObject plate_ShadeObj;
    public GameObject plateObj;
    public GameObject ringObj;
    public GameObject highlightObj;
    public Vector3 highlight_Start;
    public Vector3 highlight_end;
    float highlighttimer;

    public GameObject[] logo_Obj = new GameObject[7];
    public GameObject plate_CrackObj;
    public Sprite[] plate = new Sprite[2];
    public Sprite[] plateshade = new Sprite[2];

    public GameObject CameraObj;
    Vector3 Camerapos_init;
    Vector3 Camerapos_upleft;
    Vector3 Camerapos_upright;
    float Cameratimer;
    public float movement;

    int num;
    float[] logotimer;
    float plate_Cracktimer;
    float logointerval;
    int logoCount;
    public int movecount;
    Vector3[] logoscalmax;
    Vector3[] logoscalmin;
    Vector3 ringscalmax;
    Vector3 ringscalmin;
    Vector3 plate_Crackscalmax;
    Vector3 plate_Crackscalmin;

    public float[] text_scale;

    float plateObj_alpha;
    float ring_scal;
    // Start is called before the first frame update
    void Start()
    {
        num = 0;
        logotimer = new float[logo_Obj.Length];
        logointerval = 0.3f;
        logoCount = 0;
        movement = 20.0f;

        logoscalmax = new Vector3[logo_Obj.Length];
        logoscalmin = new Vector3[logo_Obj.Length];
        text_scale = new float[logo_Obj.Length];
        Vector3[] logo_scalinit = new Vector3[logo_Obj.Length];


        Camerapos_init = CameraObj.GetComponent<Transform>().localPosition;
        Camerapos_upleft = new Vector3(Camerapos_init.x + movement, Camerapos_init.y + movement, Camerapos_init.z);
        Camerapos_upright = new Vector3(Camerapos_init.x - movement, Camerapos_init.y - movement, Camerapos_init.z);
        


        for (int i = 0; i < logo_Obj.Length; i++)
        {
            logo_scalinit[i] = logo_Obj[i].GetComponent<RectTransform>().localScale;
            logoscalmax[i] = new Vector3(logo_scalinit[i].x * 2, logo_scalinit[i].y * 2, logo_scalinit[i].z);
            logoscalmin[i] = new Vector3(logo_scalinit[i].x, logo_scalinit[i].y, logo_scalinit[i].z);
            logo_Obj[i].GetComponent<RectTransform>().localScale = logoscalmax[i];

            logo_Obj[i].SetActive(false);
        }

        Vector3 ring_scalinit;

        ring_scalinit = ringObj.GetComponent<RectTransform>().localScale;

        ringscalmin = new Vector3(ring_scalinit.x, ring_scalinit.y, ring_scalinit.z);
        ringscalmax = new Vector3(ring_scalinit.x * 2, ring_scalinit.y * 2, ring_scalinit.z);

        Vector3 plate_Crack_scalinit;

        plate_Crack_scalinit = plate_CrackObj.GetComponent<RectTransform>().localScale;

        plate_Crackscalmin = new Vector3(plate_Crack_scalinit.x, plate_Crack_scalinit.y, plate_Crack_scalinit.z);
        plate_Crackscalmax = new Vector3(plate_Crack_scalinit.x * 3, plate_Crack_scalinit.y * 3, plate_Crack_scalinit.z);
        
        //表示off
        ringObj.SetActive(false);
        //plate_ShadeObj.SetActive(false);
        //plateObj.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        switch (num)
        {
            case 0:
                //背景プレートが1秒で出現
                plateObj.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, plateObj_alpha);
                plate_ShadeObj.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, plateObj_alpha);
                plateObj_alpha += Time.deltaTime*2;

                if (plateObj_alpha >= 1.0f)
                {
                    num = 1;
                }

                break;

            case 1:
                //リング→文字の順に出現
                //リング
                ringObj.SetActive(true);
                ringObj.GetComponent<RectTransform>().localScale = Vector3.Lerp(ringscalmax, ringscalmin, ring_scal);
                ring_scal += Time.deltaTime;

                //ク[3]
                if (ring_scal >= logointerval)
                {
                    logo_Obj[3].SetActive(true);
                    logotimer[3] += Time.deltaTime * 2;
                }

                logo_Obj[3].GetComponent<RectTransform>().localScale = Vector3.Lerp(logoscalmax[3], logoscalmin[3], logotimer[3]);
                //サ[1]

                if (logotimer[3] >= logointerval)
                {
                    logo_Obj[1].SetActive(true);
                    logotimer[1] += Time.deltaTime * 2;
                }

                logo_Obj[1].GetComponent<RectTransform>().localScale = Vector3.Lerp(logoscalmax[1], logoscalmin[1], logotimer[1]);

                //ッ[5]
                if (logotimer[1] >= logointerval)
                {
                    logo_Obj[5].SetActive(true);
                    logotimer[5] += Time.deltaTime * 2;
                }

                logo_Obj[5].GetComponent<RectTransform>().localScale = Vector3.Lerp(logoscalmax[5], logoscalmin[5], logotimer[5]);

                //リ[0]
                if (logotimer[5] >= logointerval)
                {
                    logo_Obj[0].SetActive(true);
                    logotimer[0] += Time.deltaTime * 2;
                }


                logo_Obj[0].GetComponent<RectTransform>().localScale = Vector3.Lerp(logoscalmax[0], logoscalmin[0], logotimer[0]);


                //ラ[4]
                if (logotimer[0] >= logointerval)
                {
                    logo_Obj[4].SetActive(true);
                    logotimer[4] += Time.deltaTime * 2;
                }
                logo_Obj[4].GetComponent<RectTransform>().localScale = Vector3.Lerp(logoscalmax[4], logoscalmin[4], logotimer[4]);

                //シ[6]
                if (logotimer[4] >= logointerval)
                {
                    logo_Obj[6].SetActive(true);
                    logotimer[6] += Time.deltaTime * 2;
                }

                logo_Obj[6].GetComponent<RectTransform>().localScale = Vector3.Lerp(logoscalmax[6], logoscalmin[6], logotimer[6]);

                //イ[2]
                if (logotimer[6] >= logointerval)
                {
                    logo_Obj[2].SetActive(true);
                    logotimer[2] += Time.deltaTime * 2;
                }

                logo_Obj[2].GetComponent<RectTransform>().localScale = Vector3.Lerp(logoscalmax[2], logoscalmin[2], logotimer[2]);

                if (logotimer[2] >= 1.0f)
                {
                    num = 2;
                }
                
                break;

            case 2:
                //ロゴ(割れ)段々小さくなって登場
                plate_CrackObj.SetActive(true);
                plate_CrackObj.GetComponent<RectTransform>().localScale = Vector3.Lerp(plate_Crackscalmax, plate_Crackscalmin, plate_Cracktimer);
                plate_Cracktimer += Time.deltaTime*3;
                //ロゴ(割れ)がロゴ(分割)と同じ大きさになったらプレート(分割)を割れ分割に変更後,ロゴ(割れ)をfalse
                if(plate_Cracktimer>=1.0f)
                {
                    plateObj.GetComponent<Image>().sprite = plate[1];
                    plate_CrackObj.SetActive(false);
                    num = 4;
                }
                break;

            case 3:
                //Camera揺らす
                
                Cameratimer += Time.deltaTime;
                if(Cameratimer>=0.0f&&Cameratimer<=0.3f)
                {
                    CameraObj.GetComponent<Transform>().localPosition = Camerapos_upleft;
                }
                if (Cameratimer >= 0.3f && Cameratimer <= 0.6f)
                {
                    CameraObj.GetComponent<Transform>().localPosition = Camerapos_upright;
                }
                if (Cameratimer >= 0.6f && Cameratimer <= 0.9f)
                {
                    CameraObj.GetComponent<Transform>().localPosition = Camerapos_init;
                }

                if (Cameratimer >= 0.6f)
                {
                    Cameratimer = 0.0f;
                }
                break;

            case 4:
                //ハイライト動かす
                highlightObj.GetComponent<RectTransform>().localPosition =Vector3.Lerp(highlight_Start, highlight_end, highlighttimer);
                highlighttimer += Time.deltaTime;
                if(highlighttimer>=1.0f)
                {
                    num = 5;
                }
                break;

            case 5:

                //リング回す
                ringObj.transform.Rotate(new Vector3(0, 0, 2.0f));
                //ハイライト動かす
                highlightObj.GetComponent<RectTransform>().localPosition = Vector3.Lerp(highlight_Start, highlight_end, highlighttimer);
                highlighttimer += Time.deltaTime;
                if (highlighttimer >= 3.0f)
                {
                    highlighttimer = 0.0f;
                }

                    break;

            case 6:

                //一定時間で全部フェードアウト→最初からに戻す

                break;

            default:
                break;
        }




        


    }
}
