using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAIMove : MonoBehaviour
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
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerInputManager.GetEnabled())
            return;

        //rayを使用した接地判定
        //if (CheckGrounded() == true)
        {

            //前進処理
            if (Input.GetKeyDown(KeyCode.W))
            {
                animator.SetBool("Run", true);
                animator.SetBool("Idle", false);
            }

            if (Input.GetKey(KeyCode.W))
            {
                moveDirection.z = speed;
            }
            else
            {
                moveDirection.z = 0;
                animator.SetBool("Run", false);
                animator.SetBool("Idle", true);
            }

            //方向転換
            //A,Wキーのどちらも押されている時
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
            {
                //向きを変えない
                //rb.angularVelocity = Vector3.zero;
            }
            //Aキーが押されている時
            else if (Input.GetKey(KeyCode.A))
            {
                Vector3 VecRotation = rb.rotation.eulerAngles + new Vector3(0, rotateSpeed * -1 * Time.deltaTime, 0);
                rb.transform.rotation = Quaternion.Euler(VecRotation);
            }
            //Dキーが押されている時
            else if (Input.GetKey(KeyCode.D))
            {
                Vector3 VecRotation = rb.rotation.eulerAngles + new Vector3(0, rotateSpeed * Time.deltaTime, 0);
                rb.transform.rotation = Quaternion.Euler(VecRotation);
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
            Vector3 globalDirection = rb.transform.TransformDirection(moveDirection);
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
}
