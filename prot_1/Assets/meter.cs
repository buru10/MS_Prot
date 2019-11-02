using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class meter : MonoBehaviour
{
    public GameObject[] MemoryObj;

    public GameObject ControllerUI;

    public float MeterCount;
    // Start is called before the first frame update
    void Start()
    {
        MeterCount = 0;
        for (int i = 0; i < MemoryObj.Length; i++)
        {
            MemoryObj[i].GetComponent<Image>().fillAmount = MeterCount;
        }
        ControllerUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            for (int i = 0; i < MemoryObj.Length; i++)
            {
                MeterCount += 0.02f;
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            for (int i = 0; i < MemoryObj.Length; i++)
            {
                MeterCount -= 0.02f;
            }
        }

        for (int i = 0; i < MemoryObj.Length; i++)
        {
            MemoryObj[i].GetComponent<Image>().fillAmount= MeterCount;
        }

        for (int i = 0; i < MemoryObj.Length; i++)
        {
            if(MemoryObj[i].GetComponent<Image>().fillAmount >= 1.0f)
            {
                ControllerUI.SetActive(true);
            }
        }
    }
}



