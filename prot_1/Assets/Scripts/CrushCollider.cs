﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrushCollider : MonoBehaviour
{
    public GameObject ParticleObj;
    private AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BurstObject")
        {
            Instantiate(ParticleObj, transform.position, Quaternion.identity);

            // オブジェクトの子供のフラグを変更する
            foreach (Transform child in other.transform)
            {
                if (child.tag == "Minimap")
                    continue;
                if (child.tag == "Untagged")
                    continue;

                //child.GetComponent<Garbage>().bBurst = true;
            }

            BurstVoxel burstVoxel = other.gameObject.GetComponent<BurstVoxel>();
            if (burstVoxel != null)
            {
                // 旧バージョン処理
                burstVoxel.Burst();
            }
            else
            {
                // 新バージョン処理
                BurstResource burstResource = other.gameObject.GetComponent<BurstResource>();
                burstResource.Burst();
            }
        }
    }
}
