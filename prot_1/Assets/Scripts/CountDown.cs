using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    //private Text text;
    private Image image;
    //[SerializeField] Texture texture;
    [SerializeField] Sprite three;
    [SerializeField] Sprite two;
    [SerializeField] Sprite one;
    int Count;
    [SerializeField]
    StageStateManager ssm;

    // Start is called before the first frame update
    void Start()
    {
        //text = GetComponent<Text>();
        image = GetComponent<Image>();
        image.sprite = three;
        Count = 3;
    }

    // Update is called once per frame
    void Update()
    {
        //text.fontSize -= (int)(Time.deltaTime * 300);
    }

    private void OnEnable()
    {
        Count = 3;
        StartCoroutine("Coroutine");
    }

    IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(1.0f);

        //text.text = "2";
        //image.wi = 300;
        image.sprite = two;

        yield return new WaitForSeconds(1.0f);

        //text.text = "1";
        //text.fontSize = 300;
        image.sprite = one;

        yield return new WaitForSeconds(1.0f);

        ssm.ChangeState(StageStateManager.StageState.Main);

        yield return null;
    }
}
