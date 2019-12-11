using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceRotator : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    float RotSpeed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.rotation *= Quaternion.AngleAxis(RotSpeed, Vector3.up);
    }

    private void OnEnable()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody>();
    }
}
