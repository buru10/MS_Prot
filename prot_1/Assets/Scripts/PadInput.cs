using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadInput : MonoBehaviour
{
    [SerializeField]
    SceneChanger sceneChanger;
    private AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Attack") || Input.GetKeyDown(KeyCode.B))
        {
            audio.Play();
            sceneChanger.ChangeToNext();
        }
    }
}
