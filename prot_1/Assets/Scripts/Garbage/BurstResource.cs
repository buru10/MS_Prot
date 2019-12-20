using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstResource : MonoBehaviour
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
        // デバッグ確認
        if (Input.GetKeyDown(KeyCode.B))
            Burst();
    }

    public void Burst()
    {
        var random = new System.Random();

        //Destroy(MinimapIcon);
        //Destroy(Model);

        this.GetComponent<BoxCollider>().enabled = false;

        //foreach (Rigidbody r in gameObject.GetComponentsInChildren<Rigidbody>())
        foreach (Transform obj in this.transform)
        {
            if (obj.tag != "wood"
                && obj.tag != "plastic"
                && obj.tag != "glass"
                && obj.tag != "metal")
            {
                Destroy(obj.gameObject);
                continue;
            };

            Rigidbody r = obj.GetComponent<Rigidbody>();
            r.isKinematic = false;
            r.useGravity = true;
            var vect = new Vector3(random.Next(min, max), random.Next(0, max), random.Next(min, max));
            r.AddForce(vect, ForceMode.Impulse);
            //r.AddTorque(vect, ForceMode.Impulse);
            BoxCollider boxCollider = obj.GetComponent<BoxCollider>();
            boxCollider.enabled = true;
            boxCollider.isTrigger = false;
            obj.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
        };
    }
}
