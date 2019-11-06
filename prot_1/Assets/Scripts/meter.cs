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

    public GameObject[] MemoryObj;

    public GameObject ControllerUI;

    [HideInInspector]
    public float[] MeterCount = new float[4];

    public Player Player;

    int i;

    enum Resources
    {
        metal = 0,
        paper,
        plastic,
        glass,
        Resourcesmax

    };
    // Start is called before the first frame update
    void Start()
    {
        MeterCount = new float[4];
        //Debug.Log(MeterCount[0]); 

        MemoryObj[(int)Resources.metal].GetComponent<Image>().fillAmount = 0.5f;
        //メーター初期化
        //for (int i = 0; i < MemoryObj.Length; i++)
        //{

        // Debug.Log(i);
        //   MemoryObj[i].GetComponent<Image>().fillAmount = 0;
        // }
        ControllerUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        /* if (Input.GetKeyDown(KeyCode.UpArrow))
         {
             for (int i = 0; i < MemoryObj.Length; i++)
             {
                 //MeterCount += (Player.GetResources("metal"))/10;
             }
         }
         else if (Input.GetKeyDown(KeyCode.DownArrow))
         {
             for (int i = 0; i < MemoryObj.Length; i++)
             {
                // MeterCount -= 0.02f;
             }
         }
        for (int i = 0; i < MemoryObj.Length; i++)
        {
            MemoryObj[i].GetComponent<Image>().fillAmount = MeterCount[i];
        }

        

       // MeterCount[0] = (Player.GetResources("metal")) / 10.0f;
       // MeterCount[(int)Resources.paper] = (Player.GetResources("paper")) / 10.0f;
        //MeterCount[(int)Resources.plastic] = (Player.GetResources("plastic")) / 10.0f;
       // MeterCount[(int)Resources.glass] = (Player.GetResources("glass")) / 10.0f;
*/

        MeterCount[(int)Resources.metal] = Player.GetResources("metal") / metalmax;
        MeterCount[(int)Resources.paper] = Player.GetResources("paper") / papermax;
        MeterCount[(int)Resources.plastic] = Player.GetResources("plastic") / plasticmax;
        MeterCount[(int)Resources.glass] = Player.GetResources("glass") / glassmax;

        MemoryObj[(int)Resources.metal].GetComponent<Image>().fillAmount = MeterCount[(int)Resources.metal];
        MemoryObj[(int)Resources.paper].GetComponent<Image>().fillAmount = MeterCount[(int)Resources.paper];
        MemoryObj[(int)Resources.plastic].GetComponent<Image>().fillAmount = MeterCount[(int)Resources.plastic];
        MemoryObj[(int)Resources.glass].GetComponent<Image>().fillAmount = MeterCount[(int)Resources.glass];


        if (MemoryObj[i].GetComponent<Image>().fillAmount >= 1.0f && ControllerUI.activeSelf == false)
        {
            i++;
        }

        if (i >= (int)Resources.Resourcesmax)
        {
            ControllerUI.SetActive(true);
            i = 0;
        }
        // Debug.Log("metal" + Player.GetResources("metal"));
        //Debug.Log("paper" + Player.GetResources("paper"));
        //Debug.Log("plastic" + Player.GetResources("plastic"));
        //Debug.Log("glass" + Player.GetResources("glass"));
    }
}



