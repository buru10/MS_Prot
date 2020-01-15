using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapIconRotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraRot = Camera.main.transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(new Vector3(90.0f, cameraRot.y, 0.0f));
    }
}
