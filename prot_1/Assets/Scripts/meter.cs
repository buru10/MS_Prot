using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class meter : MonoBehaviour
{
    public float metalmax;
    public float papermax;
    public float plasticmax;
    public float glassmax;
    public float woodmax;

    float metermax;
    // public GameObject[] MemoryObj;

    public GameObject[] needle;

    public GameObject ControllerUI;

    [HideInInspector]
    public float[] MeterCount = new float[5];

    public Player Player;

    int i;
    Vector3[] localAngle = new Vector3[5];
   

    enum Resources
    {
        metal = 0,
        paper,
        plastic,
        glass,
        wood,
        Resourcesmax

    };
    // Start is called before the first frame update
    void Start()
    {
        MeterCount = new float[5];
        //Debug.Log(MeterCount[0]); 

        //  MemoryObj[(int)Resources.metal].GetComponent<Image>().fillAmount = 0.5f;
        //メーター初期化
        //for (int i = 0; i < MemoryObj.Length; i++)
        //{

        // Debug.Log(i);
        //   MemoryObj[i].GetComponent<Image>().fillAmount = 0;
        // }
        ControllerUI.SetActive(false);
        metermax = 270.0f;


    }

    // Update is called once per frame
    void Update()
    {
        /*
        for (int i = 0; i < MemoryObj.Length; i++)
        {
            MemoryObj[i].GetComponent<Image>().fillAmount = MeterCount[i];
        }

        

       // MeterCount[0] = (Player.GetResources("metal")) / 10.0f;
       // MeterCount[(int)Resources.paper] = (Player.GetResources("paper")) / 10.0f;
        //MeterCount[(int)Resources.plastic] = (Player.GetResources("plastic")) / 10.0f;
       // MeterCount[(int)Resources.glass] = (Player.GetResources("glass")) / 10.0f;
*/

        MeterCount[(int)Resources.metal] = Player.GetResources("metal");
        MeterCount[(int)Resources.paper] = Player.GetResources("paper");
        MeterCount[(int)Resources.plastic] = Player.GetResources("plastic");
        MeterCount[(int)Resources.glass] = Player.GetResources("glass");
        MeterCount[(int)Resources.wood] = Player.GetResources("wood");

        /* MemoryObj[(int)Resources.metal].GetComponent<Image>().fillAmount = MeterCount[(int)Resources.metal];
          MemoryObj[(int)Resources.paper].GetComponent<Image>().fillAmount = MeterCount[(int)Resources.paper];
          MemoryObj[(int)Resources.plastic].GetComponent<Image>().fillAmount = MeterCount[(int)Resources.plastic];
          MemoryObj[(int)Resources.glass].GetComponent<Image>().fillAmount = MeterCount[(int)Resources.glass];

*/
        /*if (localAngle[i].z >= metermax && ControllerUI.activeSelf == false)
        {
            i++;
        }*/



        if (MeterCount[(int)Resources.metal] >= metalmax)
        {
            localAngle[0].z = -270;

        }
        else
        {
            localAngle[0] = needle[0].transform.localEulerAngles;
            localAngle[0].z = -(metermax / metalmax * (MeterCount[(int)Resources.metal])); // local座標を基準に、z軸を軸にした回転を10度に変更

        }
        needle[0].transform.localEulerAngles = localAngle[0]; // 回転角度を設定

        //if (MeterCount[(int)Resources.paper] >= papermax)
        //{
        //    localAngle[1].z = -270;

        //}
        //else
        //{
        //    localAngle[1] = needle[1].transform.localEulerAngles;
        //    localAngle[1].z = -(metermax / papermax * (MeterCount[(int)Resources.paper])); // local座標を基準に、z軸を軸にした回転を10度に変更

        //}
        //needle[1].transform.localEulerAngles = localAngle[1]; // 回転角度を設定
        if (MeterCount[(int)Resources.wood] >= woodmax)
        {
            localAngle[1].z = -270;

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

        }
        else
        {
            localAngle[2] = needle[0].transform.localEulerAngles;
            localAngle[2].z = -(metermax / plasticmax * (MeterCount[(int)Resources.plastic])); // local座標を基準に、z軸を軸にした回転を10度に変更
        }
        needle[2].transform.localEulerAngles = localAngle[2]; // 回転角度を設定


        if (MeterCount[(int)Resources.glass] >= glassmax)
        {
            localAngle[3].z = -270;

        }
        else
        {
            localAngle[3] = needle[0].transform.localEulerAngles;
            localAngle[3].z = -(metermax / glassmax * (MeterCount[(int)Resources.glass])); // local座標を基準に、z軸を軸にした回転を10度に変更
        }
        needle[3].transform.localEulerAngles = localAngle[3]; // 回転角度を設定




        if (MeterCount[(int)Resources.metal] >= metalmax && MeterCount[(int)Resources.wood] >= woodmax && MeterCount[(int)Resources.plastic] >= plasticmax && MeterCount[(int)Resources.glass] >= glassmax && ControllerUI.activeSelf == false)
        {
            ControllerUI.SetActive(true);
            i = 0;
        }
        
    }
}



