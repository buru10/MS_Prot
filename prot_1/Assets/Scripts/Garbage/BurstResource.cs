using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstResource : MonoBehaviour
{
    //[SerializeField]
    //GameObject MinimapIcon;
    //[SerializeField]
    //GameObject Model;
    [SerializeField]
    int min = -3;
    [SerializeField]
    int max = 3;

    [SerializeField]
    bool canHit = true;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // デバッグ確認
        //if (Input.GetKeyDown(KeyCode.B))
        //Burst();
    }

    public void Burst()
    {
        if (!canHit)
            return;

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
                && obj.tag != "metal"
                && obj.tag != "BurstObject")
            {
                Destroy(obj.gameObject);
                continue;
            }

            //obj.parent = obj.parent.parent;
            Rigidbody r = obj.GetComponent<Rigidbody>();
            if(r == null)
            {
                r = obj.gameObject.AddComponent<Rigidbody>();
                r.useGravity = true;
                r.isKinematic = false;
            }
            r.isKinematic = false;
            r.useGravity = true;

            var vect = new Vector3(random.Next(min, max), random.Next(0, max), random.Next(min, max));

            if (obj.tag == "BurstObject")
            {
                r.AddTorque(vect, ForceMode.Impulse);

                BurstResource burstResource = obj.GetComponent<BurstResource>();
                burstResource.CallCoroutine();
            }
            else
            {
                obj.GetComponent<Garbage>().bBurst = true;
                obj.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
                r.rotation = Quaternion.Euler(new Vector3(0.0f, r.rotation.eulerAngles.y, 0.0f));
                obj.GetComponent<ResourceRotator>().enabled = true;
            }
            r.AddForce(vect, ForceMode.Impulse);


            BoxCollider boxCollider = obj.GetComponent<BoxCollider>();
            boxCollider.enabled = true;
            boxCollider.isTrigger = false;         
        }

        MeshRenderer mesh = GetComponent<MeshRenderer>();
        if (mesh)
        {
            mesh.enabled = false;
        }

        GetComponent<Rigidbody>().isKinematic = true;
    }

    public void CallCoroutine()
    {
        StartCoroutine("Coroutine");
    }

    IEnumerator Coroutine()
    {
        canHit = false;
        yield return new WaitForSeconds(1.0f);

        canHit = true;
        yield return null;
    }
}
