using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadInput : MonoBehaviour
{
    [SerializeField]
    SceneChanger sceneChanger;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Attack"))
        {
            sceneChanger.ChangeToNext();
        }
    }
}
