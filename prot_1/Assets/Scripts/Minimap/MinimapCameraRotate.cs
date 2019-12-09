using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCameraRotate : MonoBehaviour
{
    Camera MainCamera;
    Quaternion vRotation;      // カメラの垂直回転(見下ろし回転)
    Quaternion hRotation;      // カメラの水平回転

    // Start is called before the first frame update
    void Start()
    {
        MainCamera = Camera.main;
        // 回転の初期化
        vRotation = Quaternion.Euler(90, 0, 0);         // 垂直回転(X軸を軸とする回転)は、40度見下ろす回転
        hRotation = Quaternion.identity;                // 水平回転(Y軸を軸とする回転)は、無回転
    }

    // Update is called once per frame
    void LateUpdate()
    {
        hRotation = Quaternion.Euler(new Vector3(0.0f, MainCamera.transform.rotation.eulerAngles.y, 0.0f));

        transform.rotation = hRotation * vRotation;
    }
}
