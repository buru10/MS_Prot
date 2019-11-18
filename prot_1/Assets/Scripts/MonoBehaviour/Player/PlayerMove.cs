using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    //重力等の変更ができるようにパブリック変数とする
    public float gravity;
    public float speed;
    public float jumpSpeed;
    public float rotateSpeed = 1200.0f;

    //外部から値が変わらないようにPrivateで定義
    //private CharacterController characterController;
    private Animator animator;
    private Vector3 moveDirection = Vector3.zero;
    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        //characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //rayを使用した接地判定
        //if (CheckGrounded() == true)
        {

            //前進処理
            if(Input.GetKeyDown(KeyCode.W))
            {
                animator.SetBool("Run", true);
            }

            if (Input.GetKey(KeyCode.W))
            {
                moveDirection.z = speed;
            }
            else
            {
                moveDirection.z = 0;
                animator.SetBool("Run", false);
            }

            //方向転換
            //A,Wキーのどちらも押されている時
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
            {
                //向きを変えない
                rb.angularVelocity = Vector3.zero;
            }
            //Aキーが押されている時
            else if (Input.GetKey(KeyCode.A))
            {
                //transform.Rotate(0, rotateSpeed * -1, 0);
                //rb.angularVelocity = new Vector3(0, rotateSpeed * -1 * Time.deltaTime, 0);
                Vector3 VecRotation = rb.rotation.eulerAngles + new Vector3(0, rotateSpeed * -1 * Time.deltaTime, 0);
                rb.transform.rotation = Quaternion.Euler(VecRotation);
                //rb.MoveRotation(Quaternion.Euler(VecRotation));
            }
            //Dキーが押されている時
            else if (Input.GetKey(KeyCode.D))
            {
                //transform.Rotate(0, rotateSpeed, 0);
                //rb.angularVelocity = new Vector3(0, rotateSpeed * Time.deltaTime, 0);
                Vector3 VecRotation = rb.rotation.eulerAngles + new Vector3(0, rotateSpeed * Time.deltaTime, 0);
                rb.transform.rotation = Quaternion.Euler(VecRotation);
                //rb.MoveRotation(Quaternion.Euler(VecRotation));
            }
            else
            {
                //向きを変えない
                rb.angularVelocity = Vector3.zero;
            }

            //jump
            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y = jumpSpeed;
            }

            //重力を発生させる
            moveDirection.y -= gravity * Time.deltaTime;

            //移動の実行
            //Vector3 globalDirection = transform.TransformDirection(moveDirection);
            Vector3 globalDirection = rb.transform.TransformDirection(moveDirection);
            //rb.velocity = globalDirection;
            //characterController.Move(globalDirection * Time.deltaTime);
            rb.MovePosition(rb.position + globalDirection * Time.deltaTime);

            //速度が０以上の時、Runを実行する
            //animator.SetBool("Run", moveDirection.z > 0.0f);
        }


        // === 移動処理 ===
        if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0)  //  テンキーや3Dスティックの入力（GetAxis）がゼロの時の動作
        {
            animator.SetBool("Run", false);  //  Runモーションしない
        }

        else //  テンキーや3Dスティックの入力（GetAxis）がゼロではない時の動作
        {
            var cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;  //  カメラが追従するための動作
            Vector3 direction = cameraForward * Input.GetAxis("Vertical") + Camera.main.transform.right * Input.GetAxis("Horizontal");  //  テンキーや3Dスティックの入力（GetAxis）があるとdirectionに値を返す
            animator.SetBool("Run", true);  //  Runモーションする

            ChangeDirection(direction);  //  向きを変える動作の処理を実行する（後述）
            Move(direction);  //  移動する動作の処理を実行する（後述）
        }


        // === アクション処理 ===
        //animator.SetBool("Action", Input.GetKey("x") || Input.GetButtonDown("Action1"));  //  キーorボタンを押したらアクションを実行
        //animator.SetBool("Action2", Input.GetKey("z") || Input.GetButtonDown("Action2"));  //  キーorボタンを押したらアクション2を実行
        //animator.SetBool("Action3", Input.GetKey("c") || Input.GetButtonDown("Action3"));  //  キーorボタンを押したらアクション3を実行
        //animator.SetBool("Jump", Input.GetKey("space") || Input.GetButtonDown("Jump"));  //  キーorボタンを押したらジャンプを実行（仮）

    }

    // ■向きを変える動作の処理
    void ChangeDirection(Vector3 direction)
    {
        Quaternion q = Quaternion.LookRotation(direction);          // 向きたい方角をQuaternion型に直す
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, rotateSpeed * Time.deltaTime);   // 向きを q に向けてじわ～っと変化させる.
    }


    // ■移動する動作の処理
    void Move(Vector3 direction)
    {
        rb.MovePosition(rb.position + direction * Time.deltaTime * speed);
        //characterController.Move(direction * Time.deltaTime * speed);   // プレイヤーの移動距離は時間×移動スピードの値
    }

    ////rayを使用した接地判定メソッド
    //public bool CheckGrounded()
    //{
    //    //初期位置と向き
    //    var ray = new Ray(transform.position + Vector3.up * 0.1f, Vector3.down);

    //    //rayの探索範囲
    //    var tolerance = 0.8f;

    //    //rayのHit判定
    //    //第一引数：飛ばすRay
    //    //第二引数：Rayの最大距離
    //    return Physics.Raycast(ray, tolerance);
    //}
}
