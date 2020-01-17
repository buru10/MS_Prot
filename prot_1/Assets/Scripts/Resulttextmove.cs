using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resulttextmove : MonoBehaviour
{

    public UImove UImove;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<TypefaceAnimator>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(UImove.GetTrigger())
        {
            timer += Time.deltaTime;
            if(timer>=1.0f)
            this.gameObject.GetComponent<TypefaceAnimator>().enabled = true;
        }
    }
}
