using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoveryChargeMeter : MonoBehaviour
{
    // メンバ変数定義
    public GameObject[] ResourcesObj;
    
    public void Create(string GarbageName)
    {
        // 素材指定
        switch (GarbageName)
        {
            // ガラス
            case "glass":
                Instantiate(ResourcesObj[0], transform.position, Quaternion.identity);
                break;
            // 金属
            case "metal":
                Instantiate(ResourcesObj[1], transform.position, Quaternion.identity);
                break;
            // 木
            case "wood":
                Instantiate(ResourcesObj[2], transform.position, Quaternion.identity);
                break;
            // プラスチック
            case "plastic":
                Instantiate(ResourcesObj[3], transform.position, Quaternion.identity);
                break;
            default:
                break;
        }

    }
}
