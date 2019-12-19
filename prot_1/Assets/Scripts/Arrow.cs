using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Vector3 scalemin;
    Vector3 scalemax;
    float timer;
    float rotationSpeed;
   
    // Start is called before the first frame update
    void Start()
    {
        scalemin = new Vector3(0.137939f, 0.137939f, 0.137939f);
        scalemax = new Vector3(0.2346939f, 0.2346939f, 0.2346939f);
        rotationSpeed = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer>= 2.0f)
        {
            timer = 0.0f;
        }
        // transformを取得
        Transform myTransform = this.transform;

        // ローカル座標を基準にした、サイズを取得
        Vector3 localScale = myTransform.localScale;
        if (timer <= 1.0f)
        {
            myTransform.localScale = Vector3.Lerp(scalemin, scalemax, timer);
        }
        else
        {
            myTransform.localScale = Vector3.Lerp(scalemax,scalemin,(timer%1.0f));
        }
        transform.Rotate(new Vector3(0, rotationSpeed, 0));
    }
}
