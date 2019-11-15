﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisaikuruRecovery : MonoBehaviour
{
    //スタートと終わりの目印
    public Player Player;
    public GameObject Garbage;
    public Transform PlayerMarker;
    public Transform startMarker;
    public Transform endMarker;
    public GarbageManager garbageManager;

    // スピード
    public float speed;
    public bool Snipe;

    public GameObject snipeObject;

    void Start()
    {
        // 仮ポジション設定
        endMarker = PlayerMarker;
        Snipe = false;

        if (!Player)
        Player = GameObject.Find("Test_Player").GetComponent<Player>();

        // 入れ直す
        garbageManager = GameObject.Find("GarbageManager").GetComponent<GarbageManager>();
       
        // 子供の情報を受け取る
        PlayerMarker = Player.transform.GetChild(2).gameObject.transform;

        // 新たなゴミが増えていないかチェックし増えていたら起動
        CheckGarbage();
    }

    void Update()
    {

        // ねらっていないとき
        if (!Snipe)
        {
            // オブジェクトの移動
            transform.position = Vector3.Lerp(startMarker.position, PlayerMarker.position, speed);

            // 新たなゴミが増えていないかチェックし増えていたら起動
            CheckGarbage();

            return;
        }
        else
        {
            // 狙っていたゴミが消滅したら
            if (!Garbage)
            {
                endMarker = PlayerMarker;
                Snipe = false;
                return;
            }

            // ゴミを狙う
            transform.position = Vector3.Lerp(startMarker.position, endMarker.position, speed);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        // スナイプオブジェクトが一致したら継続
        if(snipeObject != collision.gameObject)// || !Snipe)
            return;

        // タグ判定
        switch (collision.gameObject.tag)
        {
            // 金属
            case "metal":

                // プレイヤーに与える
                Player.SetResourcesPlus(collision.gameObject.tag);

                // ゴミリストの中身を消す
                garbageManager.Garbagelist.Remove(collision.gameObject);
                Destroy(collision.gameObject);

                // スナイプを外す
                Snipe = false;

                break;

            // 紙
            case "paper":

                // プレイヤーに与える
                Player.SetResourcesPlus(collision.gameObject.tag);

                // ゴミリストの中身を消す
                garbageManager.Garbagelist.Remove(collision.gameObject);
                Destroy(collision.gameObject);

                // コライダーを消しスナイプも外す
                Snipe = false;
                break;

            // プラスチック
            case "plastic":

                // プレイヤーに与える
                Player.SetResourcesPlus(collision.gameObject.tag);

                // ゴミリストの中身を消す
                garbageManager.Garbagelist.Remove(collision.gameObject);
                Destroy(collision.gameObject);

                // コライダーを消しスナイプも外す
                Snipe = false;

                break;
            // ガラス
            case "glass":

                // プレイヤーに与える
                Player.SetResourcesPlus(collision.gameObject.tag);

                // ゴミリストの中身を消す
                garbageManager.Garbagelist.Remove(collision.gameObject);
                Destroy(collision.gameObject);

                // コライダーを消しスナイプも外す
                Snipe = false;

                break;

            default:
                break;
        }

        snipeObject = null;
    }


    void CheckGarbage()
    {
        // 新たなゴミが増えていないかチェックし増えていたら起動
        if (garbageManager.Garbagelist.Count > 0)
        {
            for (int i = 0; i < garbageManager.Garbagelist.Count; i++)
            {
                Garbage = garbageManager.Garbagelist[i].gameObject;

                // そのオブジェクトが壊れているかつ狙われていなかったら狙う
                if (!Garbage.GetComponent<Garbage>().bTarget && Garbage.GetComponent<Garbage>().bBurst)
                {
                    Garbage.GetComponent<Garbage>().GetComponent<BoxCollider>().enabled = true;
                    Garbage.GetComponent<Garbage>().bTarget = true;
                    endMarker = Garbage.transform;
                    Snipe = true;
                    snipeObject = Garbage;
                    break;
                }
                // 
                Garbage = null;
            }
        }
        else
        {
            Snipe = false;
        }
    }
}
