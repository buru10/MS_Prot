using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    private Image image;
    //[SerializeField] Texture texture;
    [SerializeField] Sprite three;
    [SerializeField] Sprite two;
    [SerializeField] Sprite one;
    int Count;
    [SerializeField]
    StageStateManager ssm;
    private bool bTrigger;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        image.sprite = three;
        Count = 3;
        bTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        Count = 3;
        StartCoroutine("Coroutine");
    }

    IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(1.0f);

        image.sprite = two;

        yield return new WaitForSeconds(1.0f);

        image.sprite = one;

        yield return new WaitForSeconds(1.0f);

        bTrigger = true;
        ssm.ChangeState(StageStateManager.StageState.Main);

        yield return null;

    }

    public bool StartFlag()
    {
        return bTrigger;
    }
}
