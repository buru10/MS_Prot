using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stagenamelogo : MonoBehaviour
{
    public Vector2 Stagenamelogo_Startpos;
    public Vector2 Stagenamelogo_Endpos;
    public Vector2 Stagenamelogo_leftdownpos;

    float movetimer;

    //Start演出終了フラグをもらう所
    public　bool bstartend; 

    int switchnum;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (switchnum)
        {
            case 0:
                //Stagenamelogo_Startpos(画面外上部)からStagenamelogo_Endpos(画面下部)に移動
                this.GetComponent<RectTransform>().localPosition = Vector2.Lerp(Stagenamelogo_Startpos, Stagenamelogo_Endpos, movetimer);
                movetimer += Time.deltaTime;
                if (movetimer >= 1.0f && bstartend)
                {
                    movetimer = 0.0f;
                    switchnum = 1;
                }
                    break;
            case 1:
                //Start演出終了後画面外左部にスライド
                this.GetComponent<RectTransform>().localPosition = Vector2.Lerp(Stagenamelogo_Endpos, Stagenamelogo_leftdownpos, movetimer);
                movetimer += Time.deltaTime* 3;
                if (movetimer >= 1.0f)
                {
                    switchnum = 2;
                }
                break;
            case 2:
                //自分自身を削除
                Destroy(this.gameObject);
                break;

            default:
                break;
        }







    }
}
