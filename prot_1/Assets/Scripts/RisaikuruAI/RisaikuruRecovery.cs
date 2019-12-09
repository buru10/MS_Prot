using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class RisaikuruRecovery : MonoBehaviour
{
    //スタートと終わりの目印
    public Player Player;
    public GameObject Garbage;
    public Transform PlayerMarker;
    public Vector3 PlayerMark;
    public Transform startMarker;
    public Transform endMarker;
    public GarbageManager garbageManager;
    private RecoveryCharge recoveryCharge;
    private RisaikuruAIManager risaikuruAIManager;
    public int CreateNumber;

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
        Player = GameObject.Find("Player").GetComponent<Player>();

        // 入れ直す
        garbageManager = GameObject.Find("GarbageManager").GetComponent<GarbageManager>();

        // 制作番号
        risaikuruAIManager = GameObject.Find("RisaikuruAIManager").GetComponent<RisaikuruAIManager>();
        CreateNumber = risaikuruAIManager.GetCreateNumber();
        risaikuruAIManager.SetCreateNumberPlus();

        // 子供の情報を受け取る
        foreach (Transform child in Player.transform)
        {
            if("Back" == child.name)
            PlayerMarker = child.transform;
        }
        PlayerMark = PlayerMarker.position;


        m_navAgent = GetComponent<NavMeshAgent>();

        recoveryCharge = GetComponent<RecoveryCharge>();

        // 新たなゴミが増えていないかチェックし増えていたら起動
        CheckGarbage();
    }

    void Update()
    {
        RecoveryCheck();
        // ねらっていないとき
        if (!Snipe)
        {
            // オブジェクトの移動
            //PlayerMark = PlayerMarker.position;
            //PlayerMark += risaikuruAIManager.GetPlayerMarker(CreateNumber);
            m_navAgent.SetDestination(PlayerMarker.position);

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
            m_navAgent.destination = endMarker.position;
        }

    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("metal") ||
            collision.gameObject.CompareTag("paper") ||
            collision.gameObject.CompareTag("plastic") ||
            collision.gameObject.CompareTag("glass") ||
            collision.gameObject.CompareTag("wood") && colList.Contains(collision.gameObject))
        colList.Remove(collision.gameObject);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("metal") ||
            collision.gameObject.CompareTag("paper") ||
            collision.gameObject.CompareTag("plastic") ||
            collision.gameObject.CompareTag("glass") ||
            collision.gameObject.CompareTag("wood") && !colList.Contains(collision.gameObject))
            colList.Add(collision.gameObject);
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
            if(collision == null)
                // 衝突リストから消去
                colList.Remove(collision);

            // スナイプオブジェクトが一致したら継続
            if (snipeObject != collision || !Snipe)
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

                    // エフェクト生成
                    recoveryCharge.Create(collision.tag);
                    
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
                    
                    // エフェクト生成
                    recoveryCharge.Create(collision.tag);

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

                    // エフェクト生成
                    recoveryCharge.Create(collision.tag);

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

                    // エフェクト生成
                    recoveryCharge.Create(collision.tag);

                    // コライダーを消しスナイプも外す
                    Snipe = false;

                    break;
                // 木
                case "wood":

                    // プレイヤーに与える
                    Player.SetResourcesPlus(collision.tag);

                    // 衝突リストから消去
                    colList.Remove(collision);

                    // ゴミリストの中身を消す
                    garbageManager.Garbagelist.Remove(collision);
                    Destroy(collision);

                    // エフェクト生成
                    recoveryCharge.Create(collision.tag);

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
