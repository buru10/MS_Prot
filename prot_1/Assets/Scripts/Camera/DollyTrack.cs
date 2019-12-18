using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class DollyTrack : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera _virtualCamera;
    [SerializeField]
    private CinemachineDollyCart _DollyCart;

    [SerializeField]
    private CinemachineBrain _Brain;
    [SerializeField]
    private PlayerFollowCamera _FollowCamera;

    private CinemachineTrackedDolly _dolly;

    void Start()
    {
        // Virtual Cameraに対してGetCinemachineComponentでCinemachineTrackedDollyを取得する
        // GetComponentではなくGetCinemachineComponentなので注意
        _dolly = _virtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>();
    }

    void Update()
    {
        // パスの位置を更新する
        // 代入して良いのか不安になる変数名だけどこれでOK
        _virtualCamera.transform.position = _DollyCart.transform.position;
    }
}
