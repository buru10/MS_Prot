using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisaSpawnerAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    public GameObject RisaikuruAI;
    public GameObject RisaikuruAIObject;
    public GameObject Wipe;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        GameObject risa = Instantiate(RisaikuruAI, transform.position, transform.rotation, RisaikuruAIObject.transform);
        RisaAnimSpawn risaAnimSpawn = risa.GetComponent<RisaAnimSpawn>();
        risaAnimSpawn.risaSpawnerAnimation = this;
        risaAnimSpawn.enabled = true;
        Wipe.SetActive(true);
    }

    public void Close()
    {
        animator.SetBool("Close", true);
        //StartCoroutine("Coroutine");
    }

    void WipeOff()
    {
        StartCoroutine("Coroutine");
    }

    IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(1.0f);

        Wipe.SetActive(false);

        yield return null;
    }
}
