using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstVoxel : MonoBehaviour
{
    [SerializeField]
    int min = -3;
    [SerializeField]
    int max = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
            Burst();
    }

    void Burst()
    {
        var random = new System.Random();
        int min = -3;
        int max = 3;
       
        foreach (Rigidbody r in gameObject.GetComponentsInChildren<Rigidbody>())
        { 
            r.isKinematic = false;
            r.transform.SetParent(null);
            //r.gameObject.AddComponent<AutoDestroy>().time = 2f;
            var vect = new Vector3(random.Next(min, max), random.Next(0, max), random.Next(min, max));
            r.AddForce(vect, ForceMode.Impulse);
            r.AddTorque(vect, ForceMode.Impulse);
            r.GetComponent<BoxCollider>().isTrigger = false;
        };
        Destroy(gameObject);
    }
}
