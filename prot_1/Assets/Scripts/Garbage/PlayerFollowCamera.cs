using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowCamera : MonoBehaviour
{
    [SerializeField] private float TurnSpeed = 10.0f;   // 回転速度
    [SerializeField] private float vTurnSpeed = 2.0f;   // 垂直回転速度
    [SerializeField] private float hTurnSpeed = 2.0f;   // 水平回転速度
    [SerializeField] private float horizonalMax = 40.0f;   // 垂直回転角度制限
    [SerializeField] private float horizonalMin = -10.0f;   // 垂直回転角度制限
    [SerializeField] public Transform player;          // 注視対象プレイヤー

    [SerializeField] private float distance = 15.0f;    // 注視対象プレイヤーからカメラを離す距離
    [SerializeField] private Quaternion vRotation;      // カメラの垂直回転(見下ろし回転)
    [SerializeField] public Quaternion hRotation;      // カメラの水平回転

    [SerializeField] private LayerMask obstacleLayer;   // 障害物とするレイヤー


    void Start()
    {
        // 回転の初期化
        vRotation = Quaternion.Euler(40, 0, 0);         // 垂直回転(X軸を軸とする回転)は、40度見下ろす回転
        hRotation = Quaternion.identity;                // 水平回転(Y軸を軸とする回転)は、無回転
        transform.rotation = hRotation * vRotation;     // 最終的なカメラの回転は、垂直回転してから水平回転する合成回転

        // 位置の初期化
        // player位置から距離distanceだけ手前に引いた位置を設定します
        transform.position = player.position - transform.rotation * Vector3.forward * distance;
    }

    void LateUpdate()
    {
        // 水平回転の更新
        if (Input.GetMouseButton(0))
            hRotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * TurnSpeed, 0);

        if(Input.GetAxis("R_Stick_H") != 0.0f)
        {
            hRotation *= Quaternion.Euler(0, Input.GetAxis("R_Stick_H") * hTurnSpeed, 0);
        }

        // 垂直回転の更新
        if (Input.GetAxis("R_Stick_V") != 0.0f)
        {
            vRotation *= Quaternion.Euler(Input.GetAxis("R_Stick_V") * vTurnSpeed * -1, 0, 0);
        }

        if (vRotation.eulerAngles.x < horizonalMin)
        {
            vRotation = Quaternion.Euler(horizonalMin, 0, 0);
        }

        if (vRotation.eulerAngles.x > horizonalMax)
        {
            vRotation = Quaternion.Euler(horizonalMax, 0, 0);
        }

        // カメラの回転(transform.rotation)の更新
        // 方法1 : 垂直回転してから水平回転する合成回転とします
        transform.rotation = hRotation * vRotation;

        // カメラの位置(transform.position)の更新
        // player位置から距離distanceだけ手前に引いた位置を設定します(位置補正版)
        transform.position = player.position + new Vector3(0, 3, 0) - transform.rotation * Vector3.forward * distance;

        // めり込み防止
        RaycastHit hit;
        //　キャラクターとカメラの間に障害物があったら障害物の位置にカメラを移動させる
        if (Physics.Linecast(player.position, transform.position, out hit, obstacleLayer))
        {
            transform.position = hit.point;
        }
    }
}