using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstVoxel : MonoBehaviour
{
    [SerializeField]
    int min = -3;
    [SerializeField]
    int max = 3;

    public GameObject MinimapIcon;

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

    public void Burst()
    {
        var random = new System.Random();
        min = -3;
        max = 3;

        Destroy(MinimapIcon);

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
