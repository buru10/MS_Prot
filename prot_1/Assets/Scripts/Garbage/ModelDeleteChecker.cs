using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelDeleteChecker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      //  DeleteCheck();
    }
    
    public bool DeleteCheck()
    {
        if (transform.childCount <= 1)
        {
            foreach (Transform child in transform)
                Destroy(child.gameObject);

            Destroy(gameObject);

            return true;
        }
        else
            return false;

    }
}
