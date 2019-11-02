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
    public float speed = 1.0F;
    public bool Snipe;

    void Start()
    {
        // 仮ポジション設定
        endMarker = PlayerMarker;
        Snipe = false;

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
            // ゴミを狙う
            transform.position = Vector3.Lerp(startMarker.position, endMarker.position, speed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // タグ判定
        switch(collision.gameObject.tag)
        {
            // 金属
            case "metal":

                // プレイヤーに与える
                if (collision.gameObject.GetComponent<BoxCollider>().enabled)
                    Player.metal++;
                else
                    return;

                // ゴミリストの中身を消す
                garbageManager.Garbagelist.Remove(collision.gameObject);
                Destroy(collision.gameObject);

                // コライダーを消しスナイプも外す
                collision.gameObject.GetComponent<BoxCollider>().enabled = false;
                Snipe = false;

                // さらにゴミがあったらそこに向かわせる
                CheckGarbage();
                break;

            // 紙
            case "paper":

                // プレイヤーに与える
                if (collision.gameObject.GetComponent<BoxCollider>().enabled)
                    Player.paper++;
                else
                    return;

                // ゴミリストの中身を消す
                garbageManager.Garbagelist.Remove(collision.gameObject);
                Destroy(collision.gameObject);

                // コライダーを消しスナイプも外す
                collision.gameObject.GetComponent<BoxCollider>().enabled = false;
                Snipe = false;

                // さらにゴミがあったらそこに向かわせる
                CheckGarbage();
                break;

            // プラスチック
            case "plastic":

                // プレイヤーに与える
                if(collision.gameObject.GetComponent<BoxCollider>().enabled)
                Player.plastic++;
                else
                    return;

                // ゴミリストの中身を消す
                garbageManager.Garbagelist.Remove(collision.gameObject);
                Destroy(collision.gameObject);

                // コライダーを消しスナイプも外す
                collision.gameObject.GetComponent<BoxCollider>().enabled = false;
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
                    Snipe = true;
                    break;
                }
            }
        }
    }
}
