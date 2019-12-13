using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class meter : MonoBehaviour
{
    public float metalmax;
    //public float papermax;
    public float plasticmax;
    public float glassmax;
    public float woodmax;

    float metermax;

    public GameObject[] needle;
    public GameObject[] metereffect;
    public GameObject[] back;

    public GameObject ControllerUI;

    [HideInInspector]
    public float[] MeterCount;

    public Player Player;

    //int i;
    Vector3[] localAngle = new Vector3[5];


    enum Resources
    {
        metal = 0,
        plastic,
        glass,
        wood,
        Resourcesmax

    };
    // Start is called before the first frame update
    void Start()
    {
        MeterCount = new float[5];

        ControllerUI.SetActive(false);
        metermax = 270.0f;
        //metereffect[0].SetActive(false);
        for (int i = 0; i < 4;i++)
        {
            metereffect[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        MeterCount[(int)Resources.metal] = Player.GetResources("metal");
        // MeterCount[(int)Resources.paper] = Player.GetResources("paper");
        MeterCount[(int)Resources.plastic] = Player.GetResources("plastic");
        MeterCount[(int)Resources.glass] = Player.GetResources("glass");
        MeterCount[(int)Resources.wood] = Player.GetResources("wood");

        if (MeterCount[(int)Resources.metal] >= metalmax)
        {
            localAngle[0].z = -270;
            back[0].GetComponent<Image>().color = new Color(1, 1, 1, 1);
            metereffect[0].SetActive(true);
        }
        else
        {
            localAngle[0] = needle[0].transform.localEulerAngles;
            localAngle[0].z = -(metermax / metalmax * (MeterCount[(int)Resources.metal])); // local座標を基準に、z軸を軸にした回転を変更

        }
        needle[0].transform.localEulerAngles = localAngle[0]; // 回転角度を設定

        if (MeterCount[(int)Resources.wood] >= woodmax)
        {
            localAngle[1].z = -270;
            metereffect[1].SetActive(true);
            back[1].GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }
        else
        {
            localAngle[1] = needle[1].transform.localEulerAngles;
            localAngle[1].z = -(metermax / woodmax * (MeterCount[(int)Resources.wood])); // local座標を基準に、z軸を軸にした回転を10度に変更

        }
        needle[1].transform.localEulerAngles = localAngle[1]; // 回転角度を設定

        if (MeterCount[(int)Resources.plastic] >= plasticmax)
        {
            localAngle[2].z = -270;
            metereffect[2].SetActive(true);
            back[2].GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }
        else
        {
            localAngle[2] = needle[2].transform.localEulerAngles;
            localAngle[2].z = -(metermax / plasticmax * (MeterCount[(int)Resources.plastic])); // local座標を基準に、z軸を軸にした回転を10度に変更
        }
        needle[2].transform.localEulerAngles = localAngle[2]; // 回転角度を設定

        if (MeterCount[(int)Resources.glass] >= glassmax)
        {
            localAngle[3].z = -270;
            metereffect[3].SetActive(true);
            back[3].GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }
        else
        {
            localAngle[3] = needle[3].transform.localEulerAngles;
            localAngle[3].z = -(metermax / glassmax * (MeterCount[(int)Resources.glass])); // local座標を基準に、z軸を軸にした回転を10度に変更
        }
        needle[3].transform.localEulerAngles = localAngle[3]; // 回転角度を設定

        if (MeterCount[(int)Resources.metal] >= metalmax && MeterCount[(int)Resources.wood] >= woodmax && MeterCount[(int)Resources.plastic] >= plasticmax && MeterCount[(int)Resources.glass] >= glassmax && ControllerUI.activeSelf == false)
        {
            ControllerUI.SetActive(true);
            for (int i = 0; i < 4; i++)
            {
                back[i].transform.Rotate(new Vector3(0, 0, 1));
                
            }
            //i = 0;
        }

    }
}



