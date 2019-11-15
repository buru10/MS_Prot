using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Vector3 velocity;              // 移動方向
    [SerializeField]
    private float moveSpeed = 5.0f;        // 移動速度
    [SerializeField]
    private float applySpeed = 0.2f;       // 振り向きの適用速度
    [SerializeField]
    public PlayerFollowCamera refCamera;  // カメラの水平回転を参照する用

    //[HideInInspector]
    public int metal;
    //[HideInInspector]
    public int paper;
    //[HideInInspector]
    public int plastic;
    //[HideInInspector]
    public int glass;

    GameObject gameObj;
    void Start()
    {
        // 変数初期化
        metal = paper = plastic = glass = 0;
        gameObj = GameObject.Find("RisaikuruAIManager");

    }

    void Update()
    {
        //// WASD入力から、XZ平面(水平な地面)を移動する方向(velocity)を得ます
        //velocity = Vector3.zero;
        //if (Input.GetKey(KeyCode.W))
        //    velocity.z += 1;
        //if (Input.GetKey(KeyCode.A))
        //    velocity.x -= 1;
        //if (Input.GetKey(KeyCode.S))
        //    velocity.z -= 1;
        //if (Input.GetKey(KeyCode.D))
        //    velocity.x += 1;
        //if (Input.GetKey(KeyCode.C))
        //{
        //    Instantiate(RisaikuruAI, new Vector3(transform.position.x, transform.position.y + 5.0f, transform.position.z), Quaternion.identity, gameObj.transform);
        //}
        //// 速度ベクトルの長さを1秒でmoveSpeedだけ進むように調整します
        //velocity = velocity.normalized * moveSpeed * Time.deltaTime;

        //// いずれかの方向に移動している場合
        //if (velocity.magnitude > 0)
        //{
        //    // プレイヤーの回転(transform.rotation)の更新
        //    // 無回転状態のプレイヤーのZ+方向(後頭部)を、
        //    // カメラの水平回転(refCamera.hRotation)で回した移動の反対方向(-velocity)に回す回転に段々近づけます
        //    transform.rotation = Quaternion.Slerp(transform.rotation,
        //                                          Quaternion.LookRotation(refCamera.hRotation * -velocity),
        //                                          applySpeed);

        //    // プレイヤーの位置(transform.position)の更新
        //    // カメラの水平回転(refCamera.hRotation)で回した移動方向(velocity)を足し込みます
        //    transform.position += refCamera.hRotation * velocity;
        //}
    }

    public int GetResources(string mat)
    {
        // 素材指定
        switch (mat)
        {
            // 金属
            case "metal":
                return metal;
            // 紙
            case "paper":
                return paper;
            // プラスチック
            case "plastic":
                return plastic;
            // ガラス
            case "glass":
                return glass;
            default:
                break;
        }

        return 0;
    }

    public void SetResources(string mat, int value)
    {
        // 素材指定
        switch (mat)
        {
            // 金属
            case "metal":
                metal = value;
                break;
            // 紙
            case "paper":
                paper = value;
                break;
            // プラスチック
            case "plastic":
                plastic = value;
                break;
            // ガラス
            case "glass":
                glass = value;
                break;
            default:
                break;
        }

    }

    public void SetResourcesPlus(string mat)
    {
        // 素材指定
        switch (mat)
        {
            // 金属
            case "metal":
                metal++;
                break;
            // 紙
            case "paper":
                paper++;
                break;
            // プラスチック
            case "plastic":
                plastic++;
                break;
            // ガラス
            case "glass":
                glass++;
                break;
            default:
                break;
        }

    }
}
