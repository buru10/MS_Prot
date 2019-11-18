using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class input : MonoBehaviour
{

    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("joystick button 0"))
        {
            Debug.Log("button0");
        }
        if (Input.GetKeyDown("joystick button 1"))
        {
            Debug.Log("button1");
        }
        if (Input.GetKeyDown("joystick button 2"))
        {
            Debug.Log("button2");
        }
        if (Input.GetKeyDown("joystick button 3"))
        {
            Debug.Log("button3");
        }
        if (Input.GetKeyDown("joystick button 4"))
        {
            Debug.Log("button4");
        }
        if (Input.GetKeyDown("joystick button 5"))
        {
            Debug.Log("button5");
        }
        if (Input.GetKeyDown("joystick button 6"))
        {
            Debug.Log("button6");
        }
        if (Input.GetKeyDown("joystick button 7"))
        {
            Debug.Log("button7");
        }
        if (Input.GetKeyDown("joystick button 8"))
        {
            Debug.Log("button8");
        }
        if (Input.GetKeyDown("joystick button 9"))
        {
            Debug.Log("button9");
        }
        float hori = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        if ((hori != 0) || (vert != 0))
        {
            Debug.Log("stick:" + hori + "," + vert);
        }

        //L Stick
        float lsh = Input.GetAxis("L_Stick_H");
        float lsv = Input.GetAxis("L_Stick_V");
        if ((lsh != 0) || (lsv != 0))
        {
            Debug.Log("L stick:" + lsh + "," + lsv);
        }
        if(lsh >= 0.1f)
        {
            Player.transform.Translate(0.1f, 0.0f, 0.0f);
            
        }
        if (lsh <= -0.1f )
        {
            Player.transform.Translate(-0.1f, 0.0f, 0.0f);


        }
        if ( lsv >= 0.1)
        {
            Player.transform.Translate(0.0f, 0.0f, 0.1f);


        }
        if (lsv <= -0.1f)
        {

            Player.transform.Translate(0.0f, 0.0f, -0.1f);

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
        float rotatespeed = 1.0f;
        if ((dph != 0) || (dpv != 0))
        {
            Debug.Log("D Pad:" + dph + "," + dpv);
        }
        if (dph == 1 && dpv == 0)
        {
            Player.transform.Rotate(0.0f, rotatespeed, 0.0f);

        }
        if (dph == -1 && dpv == 0)
        {
            Player.transform.Rotate(0.0f, -rotatespeed, 0.0f);


        }
        if (dph == 0 && dpv == 1)
        {
            Player.transform.Translate(0.0f, 0.0f, 0.1f);


        }
        if (dph == 0 && dpv == -1)
        {

            Player.transform.Translate(0.0f, 0.0f, -0.1f);

        }
        //Trigger
        float Ltri = Input.GetAxis("L_Trigger");
        float Rtri = Input.GetAxis("R_Trigger");
        if (Ltri > 0)
        {
            Debug.Log("L trigger:" + Ltri);
        }
        if (Rtri > 0)
        {
            Debug.Log("R trigger:" + Rtri);
        }
        else
        {
           // Debug.Log("  trigger:none");
        }
    }
}
