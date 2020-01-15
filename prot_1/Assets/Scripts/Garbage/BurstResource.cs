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
    int ForceValue = 3;


    [SerializeField]
    bool canHit = true;

    public bool bPushed = false;
    Transform parentTransform;
    Vector3 PosOffset;

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

        if (!bPushed)
            return;

        GetComponent<Rigidbody>().position = parentTransform.position + PosOffset;
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

            var vect = new Vector3(random.Next(-ForceValue, ForceValue), random.Next(0, ForceValue), random.Next(-ForceValue, ForceValue));

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

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Shovel")
        {
            parentTransform = other.transform;
            PosOffset = transform.position - parentTransform.position;
            bPushed = true;
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        bPushed = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Shovel")
        {
            bPushed = false;
        }
    }
}
