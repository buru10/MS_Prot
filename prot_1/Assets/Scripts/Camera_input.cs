using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_input : MonoBehaviour
{
    public GameObject Player;
    public GameObject PlayerHead;
    public GameObject vCamera;

    float rotatespeed = 0.5f;
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

        Vector3 PlayerRotation = Player.transform.localEulerAngles;
        //Yボタン
        if (Input.GetKeyDown("joystick button 3"))
        {
            Debug.Log("button3");
            
            PlayerHead.transform.rotation = Quaternion.Euler(0.0f, PlayerRotation.y, 0.0f);
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
        if (lsh >= 0.1f)
        {
            Player.transform.Translate(0.1f, 0.0f, 0.0f);
            //PlayerHead.transform.Translate(0.1f, 0.0f, 0.0f);

        }
        if (lsh <= -0.1f)
        {
            Player.transform.Translate(-0.1f, 0.0f, 0.0f);
            //PlayerHead.transform.Translate(-0.1f, 0.0f, 0.0f);

        }
        if (lsv >= 0.1)
        {
            Player.transform.Translate(0.0f, 0.0f, 0.1f);
            //PlayerHead.transform.Translate(0.0f, 0.0f, 0.1f);


        }
        if (lsv <= -0.1f)
        {

            Player.transform.Translate(0.0f, 0.0f, -0.1f);
            //PlayerHead.transform.Translate(0.0f, 0.0f, -0.1f);

        }

        PlayerHead.transform.position = Player.transform.position;

        //R Stick
        float rsh = Input.GetAxis("R_Stick_H");
        float rsv = Input.GetAxis("R_Stick_V");
        if ((rsh != 0) || (rsv != 0))
        {
            Debug.Log("R stick:" + rsh + "," + rsv);
        }

        //R Stick右
        if (rsh >= 0.1f)
        {
            PlayerHead.transform.Rotate(0.0f, rotatespeed, 0.0f);


        }
        //R Stick左
        if (rsh <= -0.1f)
        {
            PlayerHead.transform.Rotate(0.0f, -rotatespeed, 0.0f);


        }


        //D-Pad
        float dph = Input.GetAxis("D_Pad_H");
        float dpv = Input.GetAxis("D_Pad_V");
        

        // transformを取得
        //Transform CameraTransform = Camera.transform;
        // 座標を取得
       // Vector3 Camerapos = CameraTransform.position;

        if ((dph != 0) || (dpv != 0))
        {
            Debug.Log("D Pad:" + dph + "," + dpv);
        }

        //Dpad右
        if (dph == 1 && dpv == 0)
        {
            Player.transform.Rotate(0.0f, rotatespeed, 0.0f);
            

        }
        //Dpad左
        if (dph == -1 && dpv == 0)
        {
            Player.transform.Rotate(0.0f, -rotatespeed, 0.0f);


        }
        //Dpad上
        if (dph == 0 && dpv == 1)
        {
            Player.transform.Translate(0.0f, 0.0f, 0.1f);
            //PlayerHead.transform.Translate(0.0f, 0.0f, 0.1f);
            //Camerapos.z += 0.1f;

        }
        //Dpad下
        if (dph == 0 && dpv == -1)
        {

            Player.transform.Translate(0.0f, 0.0f, -0.1f);
            //PlayerHead.transform.Translate(0.0f, 0.0f, -0.1f);
            //Camerapos.z -= 0.1f;

        }

        //CameraTransform.position = Camerapos;  // カメラ座標を設定

        //Trigger
        float tri = Input.GetAxis("L_R_Trigger");
        if (tri > 0)
        {
            Debug.Log("L trigger:" + tri);
        }
        else if (tri < 0)
        {
            Debug.Log("R trigger:" + tri);
        }
        else
        {
            // Debug.Log("  trigger:none");
        }
    }
}
