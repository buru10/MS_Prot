using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontObjDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("RisaikuruAIManager"))
        {
            // DontDestroyOnLoadしたオブジェクトを削除;
            GameObject gameObject = GameObject.Find("RisaikuruAIManager").GetComponent<RisaikuruAIManager>().gameObject;
            if (gameObject)
            {
                SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetActiveScene());
                Destroy(gameObject);
            }
        }
    }
}
