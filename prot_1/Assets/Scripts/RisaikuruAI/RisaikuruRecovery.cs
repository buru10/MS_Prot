using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class RisaikuruRecovery : MonoBehaviour
{
    // メンバ変数定義
    public Player Player;
    public GameObject Garbage;
    public Transform ReturnMarker;
    public Vector3 PlayerMark;
    public Transform startMarker;
    public Transform endMarker;
    //public GarbageManager garbageManager;
    public GarbageManager2 garbageManager2;
    private RecoveryCharge recoveryCharge;
    private RecoveryChargeMeter recoveryChargeMeter;
    private RisaikuruAIManager risaikuruAIManager;
    public int CreateNumber;

    // スピード
    public float Leapspeed;
    public bool Snipe;

    public GameObject snipeObject;

    // 衝突処理用
    public List<GameObject> colList = new List<GameObject>();

    private NavMeshAgent m_navAgent = null;

    // 音関連
    private AudioSource audioSource;
    private Animator animator;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();

        // 仮ポジション設定
        endMarker = ReturnMarker;
        Snipe = false;

        if (!Player)
            Player = GameObject.Find("Player").GetComponent<Player>();

        // 入れ直す
        //garbageManager = GameObject.Find("GarbageManager").GetComponent<GarbageManager>();
        garbageManager2 = GameObject.Find("GarbageManager2").GetComponent<GarbageManager2>();

        // 制作番号
        risaikuruAIManager = GameObject.Find("RisaikuruAIManager").GetComponent<RisaikuruAIManager>();
        risaikuruAIManager.AddRisa();

        // 子供の情報を受け取る
        foreach (Transform child in Player.transform)
        {
            if ("Back" == child.name)
                ReturnMarker = child.transform;
        }
        PlayerMark = ReturnMarker.position;

        m_navAgent = GetComponent<NavMeshAgent>();

        recoveryCharge = GetComponent<RecoveryCharge>();
        recoveryChargeMeter = GetComponent<RecoveryChargeMeter>();

        // 新たなゴミが増えていないかチェックし増えていたら起動
        CheckGarbage();
    }

    void Update()
    {
        RecoveryCheck();
        // ねらっていないとき
        if (!Snipe)
        {
            // アニメーション切り替え
            Idol();

            // オブジェクトの移動
            m_navAgent.SetDestination(ReturnMarker.transform.position);

            // ターゲット方向のベクトルを取得,方向を、回転情報に変換
            Vector3 relativePos = Player.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos);
            
            // 現在の回転情報と、ターゲット方向の回転情報を補完する
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Leapspeed);

            // 新たなゴミが増えていないかチェックし増えていたら起動
            CheckGarbage();

            return;
        }
        else
        {
            // 狙っていたゴミが消滅したら
            if (!Garbage)
            {
                endMarker = ReturnMarker;
                Snipe = false;
                return;
            }

            // アニメーション切り替え
            Move();

            // ゴミを狙う
            m_navAgent.destination = endMarker.position;

            // ターゲット方向のベクトルを取得,方向を、回転情報に変換
            Vector3 relativePos = endMarker.position - this.transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos);

            // 現在の回転情報と、ターゲット方向の回転情報を補完する
            transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, Leapspeed);
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
        if (garbageManager2.Garbagelist.Count > 0)
        {
            for (int i = 0; i < garbageManager2.Garbagelist.Count; i++)
            {
                Garbage = garbageManager2.Garbagelist[i].gameObject;

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

            // 回収音
            audioSource.Play();

            // アニメーション切り替え
            Recovery();

            ModelDeleteChecker mdc = collision.transform.parent.GetComponent<ModelDeleteChecker>();

            // タグ判定
            switch (collision.tag)
            {
                // 金属
                case "metal":

                    // プレイヤーに与える
                    //Player.SetResourcesPlus(collision.tag);

                    // 衝突リストから消去
                    colList.Remove(collision);

                    // ゴミリストの中身を消す
                    garbageManager2.Garbagelist.Remove(collision);

                    Destroy(collision);

                    mdc.DeleteCheck();
                    garbageManager2.CheckNorma();
                    //if(mdc.DeleteCheck())
                    //{
                    //    garbageManager2.SubCount();
                    //}

                    // エフェクト生成
                    recoveryCharge.Create(collision.tag);
                    recoveryChargeMeter.Create(collision.tag);

                    // スナイプを外す
                    Snipe = false;

                    break;

                // 紙
                case "paper":

                    // プレイヤーに与える
                    //Player.SetResourcesPlus(collision.tag);

                    // 衝突リストから消去
                    colList.Remove(collision);

                    // ゴミリストの中身を消す
                    garbageManager2.Garbagelist.Remove(collision);
                    
                    Destroy(collision);

                    mdc.DeleteCheck();
                    garbageManager2.CheckNorma();
                    //if(mdc.DeleteCheck())
                    //{
                    //    garbageManager2.SubCount();
                    //}

                    // エフェクト生成
                    recoveryCharge.Create(collision.tag);
                    recoveryChargeMeter.Create(collision.tag);

                    // コライダーを消しスナイプも外す
                    Snipe = false;
                    break;

                // プラスチック
                case "plastic":

                    // プレイヤーに与える
                    // Player.SetResourcesPlus(collision.tag);

                    // 衝突リストから消去
                    colList.Remove(collision);

                    // ゴミリストの中身を消す
                    garbageManager2.Garbagelist.Remove(collision);
                    
                    Destroy(collision);

                    mdc.DeleteCheck();
                    garbageManager2.CheckNorma();
                    //if(mdc.DeleteCheck())
                    //{
                    //    garbageManager2.SubCount();
                    //}

                    // エフェクト生成
                    recoveryCharge.Create(collision.tag);
                    recoveryChargeMeter.Create(collision.tag);

                    // コライダーを消しスナイプも外す
                    Snipe = false;

                    break;
                // ガラス
                case "glass":

                    // プレイヤーに与える
                    // Player.SetResourcesPlus(collision.tag);

                    // 衝突リストから消去
                    colList.Remove(collision);

                    // ゴミリストの中身を消す
                    garbageManager2.Garbagelist.Remove(collision);
                    
                    Destroy(collision);

                    mdc.DeleteCheck();
                    garbageManager2.CheckNorma();
                    //if(mdc.DeleteCheck())
                    //{
                    //    garbageManager2.SubCount();
                    //}

                    // エフェクト生成
                    recoveryCharge.Create(collision.tag);
                    recoveryChargeMeter.Create(collision.tag);

                    // コライダーを消しスナイプも外す
                    Snipe = false;

                    break;
                // 木
                case "wood":

                    // プレイヤーに与える
                    //Player.SetResourcesPlus(collision.tag);

                    // 衝突リストから消去
                    colList.Remove(collision);

                    // ゴミリストの中身を消す
                    garbageManager2.Garbagelist.Remove(collision);

                    Destroy(collision);

                    mdc.DeleteCheck();
                    garbageManager2.CheckNorma();
                    //if(mdc.DeleteCheck())
                    //{
                    //    garbageManager2.SubCount();
                    //}

                    // エフェクト生成
                    recoveryCharge.Create(collision.tag);
                    recoveryChargeMeter.Create(collision.tag);

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

    void Idol()
    {
        animator.SetBool("Idol", true);
        animator.SetBool("Move", false);
    }

    void Move()
    {
        animator.SetBool("Idol", false);
        animator.SetBool("Catch", false);
        animator.SetBool("Move", true);
    }

    void Recovery()
    {
        animator.SetBool("Move", false);
        animator.SetBool("Catch", true);
    }
}
