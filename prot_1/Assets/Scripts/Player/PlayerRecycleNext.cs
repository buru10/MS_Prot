using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRecycleNext : MonoBehaviour
{
    public GarbageManager2 manager;
    private UImove imove;
    [SerializeField] SceneChanger sceneChanger;
    [SerializeField] StageStateManager ssm;

    // Start is called before the first frame update
    void Start()
    {
        imove = GetComponent<UImove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.GetPercentage() >= 100)
        {
            imove.enabled = true;
            if (imove.GetTrigger2())
            {
                sceneChanger.ChangeToNext();
                ssm.ChangeState(StageStateManager.StageState.ShutDown);
            }
        }
    }
}
