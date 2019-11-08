using System.Collections;
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
    public int SnipeNumber;

    private SphereCollider sphereCollider;

    void Start()
    {
        // 仮ポジション設定
        endMarker = PlayerMarker;
        Snipe = false;
        SnipeNumber = 0;

        if(!Player)
        Player = GameObject.Find("Test_Player").GetComponent<Player>();

        // 入れ直す
        garbageManager = GameObject.Find("GarbageManager").GetComponent<GarbageManager>();
        

        // 判定を消す
        sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.enabled = false;

        // 子供の情報を受け取る
        PlayerMarker = Player.transform.GetChild(0).transform.GetChild(0).gameObject.transform;

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
            if(!Garbage)
            {
                endMarker = PlayerMarker;
                Snipe = false;
                return;
            }

            if (Snipe)
                if (!endMarker)
                {
                    endMarker = PlayerMarker;
                    Snipe = false;
                }

            // ゴミを狙う
            transform.position = Vector3.Lerp(startMarker.position, endMarker.position, speed);
            if (speed >= 1.0f)
            {
                speed = 0.0f;
                sphereCollider.enabled = true;

            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //// スナイプナンバーが一致したら継続
        //if (SnipeNumber != collision.gameObject.GetComponent<Billboard>().CreateNumber)
        //    return;

        // タグ判定
        switch (collision.gameObject.tag)
        {
            // 金属
            case "metal":

                // プレイヤーに与える
                if (collision.gameObject.GetComponent<BoxCollider>().enabled)
                    Player.SetResourcesPlus(collision.gameObject.tag);
                else
                    return;

                // ゴミリストの中身を消す
                garbageManager.Garbagelist.Remove(collision.gameObject);
                Destroy(collision.gameObject);

                // コライダーを消しスナイプも外す
                collision.gameObject.GetComponent<BoxCollider>().enabled = false;
                sphereCollider.enabled = false;
                Snipe = false;

                // さらにゴミがあったらそこに向かわせる
                CheckGarbage();
                break;

            // 紙
            case "paper":

                // プレイヤーに与える
                if (collision.gameObject.GetComponent<BoxCollider>().enabled)
                    Player.SetResourcesPlus(collision.gameObject.tag);
                else
                    return;

                // ゴミリストの中身を消す
                garbageManager.Garbagelist.Remove(collision.gameObject);
                Destroy(collision.gameObject);

                // コライダーを消しスナイプも外す
                collision.gameObject.GetComponent<BoxCollider>().enabled = false;
                sphereCollider.enabled = false;
                Snipe = false;

                // さらにゴミがあったらそこに向かわせる
                CheckGarbage();
                break;

            // プラスチック
            case "plastic":

                // プレイヤーに与える
                if (collision.gameObject.GetComponent<BoxCollider>().enabled)
                    Player.SetResourcesPlus(collision.gameObject.tag);
                else
                    return;

                // ゴミリストの中身を消す
                garbageManager.Garbagelist.Remove(collision.gameObject);
                Destroy(collision.gameObject);

                // コライダーを消しスナイプも外す
                collision.gameObject.GetComponent<BoxCollider>().enabled = false;
                sphereCollider.enabled = false;
                Snipe = false;

                // さらにゴミがあったらそこに向かわせる
                CheckGarbage();
                break;
            // ガラス
            case "glass":

                // プレイヤーに与える
                if (collision.gameObject.GetComponent<BoxCollider>().enabled)
                    Player.SetResourcesPlus(collision.gameObject.tag);
                else
                    return;

                // ゴミリストの中身を消す
                garbageManager.Garbagelist.Remove(collision.gameObject);
                Destroy(collision.gameObject);

                // コライダーを消しスナイプも外す
                collision.gameObject.GetComponent<BoxCollider>().enabled = false;
                sphereCollider.enabled = false;
                Snipe = false;

                // さらにゴミがあったらそこに向かわせる
                CheckGarbage();
                break;

            default:
                break;
        }
    }

    void CheckGarbage()
    {
        // 新たなゴミが増えていないかチェックし増えていたら起動
        if (garbageManager.Garbagelist.Count > 0)
        {
            for (int i = 0; i < garbageManager.Garbagelist.Count; i++)
            {
                Garbage = garbageManager.Garbagelist[i].gameObject;

                // そのオブジェクトが狙われていなかったら狙う
                if (!Garbage.GetComponent<Billboard>().bTarget)
                {
                    Garbage.GetComponent<Billboard>().GetComponent<BoxCollider>().enabled = true;
                    Garbage.GetComponent<Billboard>().bTarget = true;
                    endMarker = Garbage.transform;
                    //SnipeNumber = Garbage.GetComponent<Billboard>().CreateNumber; // スナイプナンバー記憶
                    Snipe = true;
                    break;
                }
            }
        }
        else
        {
            Snipe = false;
        }
    }
}
