using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PushButton : MonoBehaviour
{
    public GameObject ControllerObj;

    public Sprite ControllerImagetrue;
    public Sprite ControllerImagefalse;

    float InitTime;
    float TimeCount;

    public meter meter;
    // Start is called before the first frame update
    void Start()
    {
        InitTime = 0.5f;
        TimeCount = InitTime;
    }

    // Update is called once per frame
    void Update()
    {
        TimeCount -= Time.deltaTime;
        if (TimeCount <= 0)
        {
            ControllerObj.GetComponent<Image>().sprite = ControllerImagefalse;
            TimeCount = InitTime;
        }
        else if (TimeCount <= InitTime / 2)
        {
            ControllerObj.GetComponent<Image>().sprite = ControllerImagetrue;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            this.gameObject.SetActive(false);
            meter.MeterCount = 0;
        }

    }
}
