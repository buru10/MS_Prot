using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultTime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string tenn = ":";
        float miliSec = CountTimer.remainTime - (int)CountTimer.remainTime;
        string text = CountTimer.remainTime.ToString("##0") + tenn + miliSec.ToString("f2").Substring(2, 2);
        GetComponent<Text>().text = text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
