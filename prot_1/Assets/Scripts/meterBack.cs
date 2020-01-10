using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meterBack : MonoBehaviour
{

    public newmeter newmeter;
    public UICornersGradient UICornersGradient;
    // Start is called before the first frame update
    void Start()
    {
        //UICornersGradient.SetActive(false);
        this.GetComponent<UICornersGradient>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 1));
        if (newmeter.memoryColor == 0)
        {
            UICornersGradient.m_topLeftColor = new Color32(0, 6, 255, 255);
            UICornersGradient.m_topRightColor = new Color32(202, 0, 255, 255);
            UICornersGradient.m_bottomRightColor = new Color32(255, 83, 239, 255);
            UICornersGradient.m_bottomLeftColor = new Color32(0, 255, 247, 255);
            this.GetComponent<UICornersGradient>().enabled = true;
        }
        else if(newmeter.memoryColor == 1)
        {
            UICornersGradient.m_topLeftColor = new Color32(74, 255, 0, 255);
            UICornersGradient.m_topRightColor = new Color32(0, 223, 255, 255);
            UICornersGradient.m_bottomRightColor = new Color32(0, 14, 253, 255);
            UICornersGradient.m_bottomLeftColor = new Color32(44, 173, 6, 255);
            this.GetComponent<UICornersGradient>().enabled = true;
        }

        else if (newmeter.memoryColor == 2)
        {
            UICornersGradient.m_topLeftColor = new Color32(255, 0, 41, 255);
            UICornersGradient.m_topRightColor = new Color32(217, 105, 142, 255);
            UICornersGradient.m_bottomRightColor = new Color32(245, 170, 168, 255);
            UICornersGradient.m_bottomLeftColor = new Color32(255, 0, 5, 255);
            this.GetComponent<UICornersGradient>().enabled = true;
        }

        else if (newmeter.memoryColor == 3)
        {
            UICornersGradient.m_topLeftColor = new Color32(242, 255, 0, 255);
            UICornersGradient.m_topRightColor = new Color32(255, 202, 93, 255);
            UICornersGradient.m_bottomRightColor = new Color32(255, 44, 0, 255);
            UICornersGradient.m_bottomLeftColor = new Color32(255, 126, 0, 255);
            this.GetComponent<UICornersGradient>().enabled = true;
        }
    }
}
