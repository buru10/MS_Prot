using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GarbageManager2.Percentage = 0;
        CountTimer.remainTime = 180.0f;
        Score.Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
