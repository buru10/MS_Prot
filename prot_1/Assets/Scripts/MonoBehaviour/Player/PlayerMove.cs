using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    //重力等の変更ができるようにパブリック変数とする
    public float gravity;
    public float speed;
    public float jumpSpeed;
    public float rotateSpeed;

    //外部から値が変わらないようにPrivateで定義
    private CharacterController characterController;
    private Animator animator;
    private Vector3 moveDirection = Vector3.zero;
    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        characterController = GetComponent<CharacterController>();
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
                rb.angularVelocity = new Vector3(0, rotateSpeed * -1, 0);
            }
            //Dキーが押されている時
            else if (Input.GetKey(KeyCode.D))
            {
                //transform.Rotate(0, rotateSpeed, 0);
                rb.angularVelocity = new Vector3(0, rotateSpeed, 0);
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
            Vector3 globalDirection = transform.TransformDirection(moveDirection);
            //rb.velocity = globalDirection;
            characterController.Move(globalDirection * Time.deltaTime);

            //速度が０以上の時、Runを実行する
            //animator.SetBool("Run", moveDirection.z > 0.0f);
        }
    }

    //rayを使用した接地判定メソッド
    public bool CheckGrounded()
    {
        //初期位置と向き
        var ray = new Ray(transform.position + Vector3.up * 0.1f, Vector3.down);

        //rayの探索範囲
        var tolerance = 0.8f;

        //rayのHit判定
        //第一引数：飛ばすRay
        //第二引数：Rayの最大距離
        return Physics.Raycast(ray, tolerance);
    }
}
