using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoveryEffect : MonoBehaviour
{
    // メンバ変数定義
    public Player Player;

    bool bStart;
    float speed;
    float time;


    // Start is called before the first frame update
    void Start()
    {
        if (!Player)
            Player = GameObject.Find("Player").GetComponent<Player>();

        bStart = false;
        speed = 0.02f;
    }

    // Update is called once per frame
    void Update()
    {
        time += speed;
        transform.position = Vector3.Lerp(transform.position, Player.transform.position, time);

        if (time >= 1.0f) Destroy(gameObject);
    }
}
