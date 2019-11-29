using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Startlogo : MonoBehaviour
{
    Vector3 initTextscal;
    Vector3 endTextscal;

    float timeStepText;

    [SerializeField]
    float timeTextpop;

    public bool bStart;//true=Start演出中

    // Start is called before the first frame update
    void Start()
    {
        initTextscal = new Vector3(0.1f, 0.1f, 0.0f);
        endTextscal = new Vector3(1.0f, 1.0f, 0.0f);

        this.transform.localScale = initTextscal;

        timeStepText = 0.0f;
        this.gameObject.GetComponent<Image>().enabled=true;
        bStart = true;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.localScale = Vector3.Lerp(initTextscal, endTextscal, timeStepText);
        timeStepText += Time.deltaTime / timeTextpop;

        if (timeStepText >= 1.5)
        {
            this.gameObject.SetActive(false);
            bStart = false;
        }
    }
}
