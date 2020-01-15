using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDownActive : MonoBehaviour
{
    public CountDown countDown;

    public GameObject[] gameObjects;

    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < gameObjects.Length; i++)
            gameObjects[i].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(countDown.StartFlag())
        {
            for (int i = 0; i < gameObjects.Length; i++)
                gameObjects[i].SetActive(true);
        }
    }
}
