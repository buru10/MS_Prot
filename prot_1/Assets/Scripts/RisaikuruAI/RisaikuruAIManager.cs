using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisaikuruAIManager : MonoBehaviour
{
    // メンバ変数定義
    public Player Player;
    public Vector3 PlayerMarker;
    public Vector3[] OffSet;

    private int CreateNumber;
    private int nCnt;
    private int nNum;
    private int nNumSave;

    // Start is called before the first frame update
    void Awake()
    {
        nCnt = 0;
        CreateNumber = 1;

        if (!Player)
            Player = GameObject.Find("Player").GetComponent<Player>();
       
        // 子供の情報を受け取る
        foreach (Transform child in Player.transform)
        {
            if ("Back" == child.name)
                PlayerMarker = child.transform.position;
        }

        OffSet[0]  = new Vector3( 0.0f,0.0f, 0.0f);
        OffSet[1]  = new Vector3(-1.0f,0.0f,-1.0f);
        OffSet[2]  = new Vector3( 1.0f,0.0f,-1.0f);
        OffSet[3]  = new Vector3(-2.0f,0.0f,-2.0f);
        OffSet[4]  = new Vector3( 0.0f,0.0f,-2.0f);
        OffSet[5]  = new Vector3( 2.0f,0.0f,-2.0f);
        OffSet[6]  = new Vector3(-3.0f,0.0f,-3.0f);
        OffSet[7]  = new Vector3(-1.0f,0.0f,-3.0f);
        OffSet[8]  = new Vector3( 1.0f,0.0f,-3.0f);
        OffSet[9]  = new Vector3( 3.0f,0.0f,-3.0f);
        OffSet[10] = new Vector3(-4.0f,0.0f,-4.0f);
        OffSet[11] = new Vector3(-2.0f,0.0f,-4.0f);
        OffSet[12] = new Vector3( 0.0f,0.0f,-4.0f);
        OffSet[13] = new Vector3( 2.0f,0.0f,-4.0f);
        OffSet[14] = new Vector3( 4.0f,0.0f,-4.0f);

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

        // 最初の一個はplayerの座標を参照してね
        //// ここでcurrentLineが１になる。１列目なので
        //// 1列目なら1個saysay2列目なら2個saysay
        //if (lineNum < currentLine)
        //    currentLine++;

        //// 列が更新されていたとき
        //if (currentLine != prevCurrentLine)
        //{
        //    // 親の配列番号を特定
        //    parentNum = CreateNum - prevCurrentLine;

        //    // 親の位置から列の先頭の位置を決める。これはたぶん左後ろらへん^^
        //    transform = OffSet[parentNum] + new Vector3(-1.0f, 0.0f, -1.0f);

        //    // 列の先頭なのでCnt初期化
        //    lineNum = 0;
        //}
        //// 列が更新されていないとき
        //else
        //{
        //    // 子供を作る的な
        //    transform = OffSet[CreateNum - 1];
        //}

        //// みかんCnt更新
        //lineNum++;

        //// prevCurrentLine更新
        //prevCurrentLine = currentLine;

        ////----------------------------------------------
        //// end
        ////----------------------------------------------

        for (int i = 0; i < CreateNum; i++)
        {
            //PlayerMarker.x += CreateNumber;
            //PlayerMarker.z -= 1.0f;

            transform = OffSet[CreateNum - 1];
        }

        return transform;
    }

}
