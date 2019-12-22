using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBloom : MonoBehaviour
{

    Material useMat;
    [ColorUsage(false, true)]
    [SerializeField]
    Color[] colorArray;

    [SerializeField]
    float maxTimer;

    int colorUsing;

    float nowTimer;

    float marginTimer;

    // Use this for initialization
    void Start()
    {
        colorUsing = 0;
        marginTimer = 1 / maxTimer;
        useMat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {

        useMat.EnableKeyword("_EMISSION");
        useMat.SetColor("_EmissionColor", Color.Lerp(colorArray[colorUsing], colorArray[1 - colorUsing], nowTimer * marginTimer));

        nowTimer += Time.deltaTime;

        if (nowTimer > maxTimer)
        {
            nowTimer = 0;

            colorUsing ^= 1;
        }


    }
}
