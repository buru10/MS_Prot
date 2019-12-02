using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoveryCharge : MonoBehaviour
{
    // メンバ変数定義
    public GameObject[] ParticleObj;
    
    public void Create(string GarbageName)
    {
        // 素材指定
        switch (GarbageName)
        {
            // ガラス
            case "glass":
                Instantiate(ParticleObj[0], transform.position, Quaternion.identity);
                break;
            // 金属
            case "metal":
                Instantiate(ParticleObj[1], transform.position, Quaternion.identity);
                break;
            // 木
            case "wood":
                Instantiate(ParticleObj[2], transform.position, Quaternion.identity);
                break;
            // プラスチック
            case "plastic":
                Instantiate(ParticleObj[3], transform.position, Quaternion.identity);
                break;
            default:
                break;
        }

    }
}
