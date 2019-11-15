﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
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

    // 衝突処理用
    public List<GameObject> colList = new List<GameObject>();

    private NavMeshAgent m_navAgent = null;

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

        m_navAgent = GetComponent<NavMeshAgent>();

        // 新たなゴミが増えていないかチェックし増えていたら起動
        CheckGarbage();
    }

    void Update()
    {

        // ねらっていないとき
        if (!Snipe)
        {
            // オブジェクトの移動
           // m_navAgent.destination = PlayerMarker.position;
             transform.position = Vector3.Lerp(startMarker.position, PlayerMarker.position, speed);

            // 新たなゴミが増えていないかチェックし増えていたら起動
            CheckGarbage();

            return;
        }
        else
        {
            RecoveryCheck();

            // 狙っていたゴミが消滅したら
            if (!Garbage)
            {
                endMarker = PlayerMarker;
                Snipe = false;
                return;
            }

            // ゴミを狙う
            //m_navAgent.destination = endMarker.position;
            transform.position = Vector3.Lerp(startMarker.position, endMarker.position, speed);
        }

    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("metal") ||
            collision.gameObject.CompareTag("paper") ||
            collision.gameObject.CompareTag("plastic") ||
            collision.gameObject.CompareTag("glass") && colList.Contains(collision.gameObject))
        colList.Remove(collision.gameObject);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("metal") ||
            collision.gameObject.CompareTag("paper") ||
            collision.gameObject.CompareTag("plastic") ||
            collision.gameObject.CompareTag("glass") && !colList.Contains(collision.gameObject))
            colList.Add(collision.gameObject);

        //// スナイプオブジェクトが一致したら継続
        //if (snipeObject != collision.gameObject)// || !Snipe)
        //    return;

        //// タグ判定
        //switch (collision.gameObject.tag)
        //{
        //    // 金属
        //    case "metal":

        //        // プレイヤーに与える
        //        Player.SetResourcesPlus(collision.gameObject.tag);

        //        // ゴミリストの中身を消す
        //        garbageManager.Garbagelist.Remove(collision.gameObject);
        //        Destroy(collision.gameObject);

        //        // スナイプを外す
        //        Snipe = false;

        //        break;

        //    // 紙
        //    case "paper":

        //        // プレイヤーに与える
        //        Player.SetResourcesPlus(collision.gameObject.tag);

        //        // ゴミリストの中身を消す
        //        garbageManager.Garbagelist.Remove(collision.gameObject);
        //        Destroy(collision.gameObject);

        //        // コライダーを消しスナイプも外す
        //        Snipe = false;
        //        break;

        //    // プラスチック
        //    case "plastic":

        //        // プレイヤーに与える
        //        Player.SetResourcesPlus(collision.gameObject.tag);

        //        // ゴミリストの中身を消す
        //        garbageManager.Garbagelist.Remove(collision.gameObject);
        //        Destroy(collision.gameObject);

        //        // コライダーを消しスナイプも外す
        //        Snipe = false;

        //        break;
        //    // ガラス
        //    case "glass":

        //        // プレイヤーに与える
        //        Player.SetResourcesPlus(collision.gameObject.tag);

        //        // ゴミリストの中身を消す
        //        garbageManager.Garbagelist.Remove(collision.gameObject);
        //        Destroy(collision.gameObject);

        //        // コライダーを消しスナイプも外す
        //        Snipe = false;

        //        break;

        //    default:
        //        break;
        //}

        //snipeObject = null;
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

    void RecoveryCheck()
    {
        foreach (GameObject collision in colList)
        {
            // スナイプオブジェクトが一致したら継続
            if (snipeObject != collision)// || !Snipe)
                continue;

            // タグ判定
            switch (collision.tag)
            {
                // 金属
                case "metal":

                    // プレイヤーに与える
                    Player.SetResourcesPlus(collision.tag);

                    // 衝突リストから消去
                    colList.Remove(collision);

                    // ゴミリストの中身を消す
                    garbageManager.Garbagelist.Remove(collision);
                    Destroy(collision);

                    // スナイプを外す
                    Snipe = false;

                    break;

                // 紙
                case "paper":

                    // プレイヤーに与える
                    Player.SetResourcesPlus(collision.tag);

                    // 衝突リストから消去
                    colList.Remove(collision);

                    // ゴミリストの中身を消す
                    garbageManager.Garbagelist.Remove(collision);
                    Destroy(collision);

                    // コライダーを消しスナイプも外す
                    Snipe = false;
                    break;

                // プラスチック
                case "plastic":

                    // プレイヤーに与える
                    Player.SetResourcesPlus(collision.tag);

                    // 衝突リストから消去
                    colList.Remove(collision);

                    // ゴミリストの中身を消す
                    garbageManager.Garbagelist.Remove(collision);
                    Destroy(collision);

                    // コライダーを消しスナイプも外す
                    Snipe = false;

                    break;
                // ガラス
                case "glass":

                    // プレイヤーに与える
                    Player.SetResourcesPlus(collision.tag);

                    // 衝突リストから消去
                    colList.Remove(collision);

                    // ゴミリストの中身を消す
                    garbageManager.Garbagelist.Remove(collision);
                    Destroy(collision);

                    // コライダーを消しスナイプも外す
                    Snipe = false;

                    break;

                default:
                    break;
            }

            snipeObject = null;
            return;
        }
    }
}
