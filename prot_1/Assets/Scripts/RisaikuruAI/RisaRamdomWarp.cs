using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisaRamdomWarp : MonoBehaviour
{
    // メンバ変数定義
    public float speed =1.0f;
    float Savespeed;
    public Vector2 X;
    public Vector2 Z;

    // Start is called before the first frame update
    void Start()
    {
        Savespeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        speed -= Time.deltaTime;

        if(speed <= 0.0f)
        {
            speed = Savespeed;
            gameObject.transform.position = new Vector3(Random.Range(X.x,X.y),0.0f, Random.Range(Z.x,Z.y));
        }
    }
}
