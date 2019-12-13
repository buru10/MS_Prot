using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisaikuruAIManager : MonoBehaviour
{
    // メンバ変数定義
    public Player Player;
    public Vector3 PlayerMarker;

    private int CreateNumber;
    private int nCnt;
    private int nNum;
    private int nNumSave;

    private static int CountRisa;

    // Start is called before the first frame update
    void Awake()
    {
        // 変数初期化
        nCnt = 0;
        CreateNumber = 1;
        CountRisa = 0;


        if (!Player)
            Player = GameObject.Find("Player").GetComponent<Player>();
       
        // 子供の情報を受け取る
        foreach (Transform child in Player.transform)
        {
            if ("Back" == child.name)
                PlayerMarker = child.transform.position;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetCreateNumber()
    {
        return CreateNumber;
    }
    public void SetCreateNumberPlus()
    {
        CreateNumber++;
    }

    public Vector3 GetPlayerMarker(int CreateNum)
    {
        Vector3 transform = PlayerMarker;
        nNum = CreateNum;

        return transform;
    }

    public void AddRisa()
    {
        CountRisa++;
    }
}
