using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScore : MonoBehaviour
{
    public Text stage1;
    public Text stage2;

    // Start is called before the first frame update
    void Start()
    {
        stage1.text = Score.RecycleStage1.ToString() + "%";
        stage2.text = Score.RecycleStage2.ToString() + "%";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
