using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChanger : MonoBehaviour
{
    public string nextScene;
    private string resultScene = "Result";
    private string ToChange;
    bool bfade = false;
    [SerializeField] FadeRisa fade;
    bool bChange = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(bfade && fade.getEndFlag())
        {
            Debug.Log("シーンチェンジ");
            SceneManager.LoadScene(ToChange);
        }
    }

    public void ChangseToResult()
    {
        ToChange = resultScene;
        fade.StartFade();
        bfade = true;
    }

    public void ChangeToNext()
    {
        ToChange = nextScene;
        fade.StartFade();
        bfade = true;
    }

    public void ChangeNextSceneName(string name)
    {
        nextScene = name;
    }
}
