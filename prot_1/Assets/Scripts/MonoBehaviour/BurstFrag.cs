// オブジェクトの破片を爆散するクラス

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstFrag : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Burst(int min, int max)
    {
        var random = new System.Random();

        //Destroy(MinimapIcon);

        foreach (Rigidbody r in gameObject.GetComponentsInChildren<Rigidbody>())
        {
            r.isKinematic = false;
            r.transform.SetParent(null);
            //r.gameObject.AddComponent<AutoDestroy>().time = 2f;
            var vect = new Vector3(random.Next(min, max), random.Next(0, max), random.Next(min, max));
            r.AddForce(vect, ForceMode.Impulse);
            r.AddTorque(vect, ForceMode.Impulse);
        };
        Destroy(gameObject);
    }
}
