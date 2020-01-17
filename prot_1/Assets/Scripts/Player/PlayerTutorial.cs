using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTutorial : MonoBehaviour
{
    private PlayerAIMove player; 
    public tutorialUI tutorial;

    // Start is called before the first frame update
    void Start()
    {
        // 初期化
        PlayerInputManager.SetEnabled(false);

        player = GetComponent<PlayerAIMove>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
