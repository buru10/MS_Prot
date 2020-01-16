using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialUINext : MonoBehaviour
{
    public tutorialUI tutorial;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Attack"))
            if (!tutorial.b1_operation) tutorial.b1_operation = true;
        else if(!tutorial.b2_operation) tutorial.b2_operation = true;
        else if(!tutorial.b3_operation) tutorial.b3_operation = true;
        else if(!tutorial.b4_operation) tutorial.b4_operation = true;
        else if(!tutorial.b5_operation) tutorial.b5_operation = true;
        else if(!tutorial.b6_operation) tutorial.b6_operation = true;
    }
}
