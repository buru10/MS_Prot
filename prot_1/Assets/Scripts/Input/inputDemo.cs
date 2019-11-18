using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class inputDemo : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        //L Stick
        float lsh = Input.GetAxis("L_Stick_H");
        float lsv = Input.GetAxis("L_Stick_V");
        if ((lsh != 0) || (lsv != 0))
        {
            Debug.Log("L stick:" + lsh + "," + lsv);
        }
        //R Stick
        float rsh = Input.GetAxis("R_Stick_H");
        float rsv = Input.GetAxis("R_Stick_V");
        if ((rsh != 0) || (rsv != 0))
        {
            Debug.Log("R stick:" + rsh + "," + rsv);
        }
        //D-Pad
        float dph = Input.GetAxis("D_Pad_H");
        float dpv = Input.GetAxis("D_Pad_V");
        if ((dph != 0) || (dpv != 0))
        {
            Debug.Log("D Pad:" + dph + "," + dpv);
        }
        //Trigger
        float ltri = Input.GetAxis("L_Trigger");
        float rtri = Input.GetAxis("R_Trigger");
        if (ltri > 0)
        {
            Debug.Log("L trigger:" + ltri);
        }
        if (rtri > 0)
        {
            Debug.Log("R trigger:" + rtri);
        }
    }
}