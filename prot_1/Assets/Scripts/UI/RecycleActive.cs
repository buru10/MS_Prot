using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecycleActive : MonoBehaviour
{
    public UImove imove;
    public GarbageManager2 garbage;

    // Start is called before the first frame update
    void Start()
    {
        imove = GetComponent<UImove>();
    }

    // Update is called once per frame
    void Update()
    {
        if(garbage.GetPercentage() >= 80)
        imove.enabled = true;
    }
}
