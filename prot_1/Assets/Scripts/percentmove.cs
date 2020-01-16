using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class percentmove : MonoBehaviour
{
    public GarbageManager2 garbageManager;
    //public TypefaceAnimator TypefaceAnimator;
    int oldpercent;
    bool textmove;
    public float taimer;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<TypefaceAnimator>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (oldpercent < garbageManager.GetPercentage())
        {
            oldpercent = garbageManager.GetPercentage();
            textmove = true;
            
        }
        if(textmove)
        {
            taimer += Time.deltaTime;
            this.gameObject.GetComponent<TypefaceAnimator>().enabled = true;
            if(taimer>=1.0f)
            {
                this.gameObject.GetComponent<TypefaceAnimator>().enabled = false;
                textmove = false;
                taimer = 0.0f;
            }
        }
    }
}
