using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public UICornersGradient UICornersGradient;

    public float TimeCount = 6;
    int ColorNum;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        TimeCount -= Time.deltaTime;



        /*if (TimeCount <= 9&& TimeCount >= 7)
       {
           UICornersGradient.m_topLeftColor = Color.blue;
           UICornersGradient.m_topRightColor = Color.cyan;
           UICornersGradient.m_bottomRightColor = Color.white;
           UICornersGradient.m_bottomLeftColor = Color.green;
       }
       if (TimeCount <= 6 && TimeCount >= 4)
       {
           UICornersGradient.m_topLeftColor = Color.blue;
           UICornersGradient.m_topRightColor = Color.blue;
           UICornersGradient.m_bottomRightColor = Color.cyan;
           UICornersGradient.m_bottomLeftColor = Color.white;
       }
       if (TimeCount <= 3 && TimeCount >= 1)
       {
           UICornersGradient.m_topLeftColor = Color.white;
           UICornersGradient.m_topRightColor = Color.grey;
           UICornersGradient.m_bottomRightColor = Color.blue;
           UICornersGradient.m_bottomLeftColor = Color.cyan;
       }
      if (TimeCount <= 6)
       {
           UICornersGradient.m_topLeftColor = Color.blue;
           UICornersGradient.m_topRightColor = Color.cyan;
           UICornersGradient.m_bottomRightColor = Color.white;
           UICornersGradient.m_bottomLeftColor = Color.blue;
       }

       if (TimeCount <= 5)
       {
           UICornersGradient.m_topLeftColor = Color.blue;
           UICornersGradient.m_topRightColor = Color.cyan;
           UICornersGradient.m_bottomRightColor = Color.blue;
           UICornersGradient.m_bottomLeftColor = Color.white;
       }

       if (TimeCount <= 4)
       {
           UICornersGradient.m_topLeftColor = Color.cyan;
           UICornersGradient.m_topRightColor = Color.blue;
           UICornersGradient.m_bottomRightColor = Color.white;
           UICornersGradient.m_bottomLeftColor = Color.green;
       }

       if (TimeCount <= 3)
       {
           UICornersGradient.m_topLeftColor = Color.blue;
           UICornersGradient.m_topRightColor = Color.cyan;
           UICornersGradient.m_bottomRightColor = Color.white;
           UICornersGradient.m_bottomLeftColor = Color.white;
       }

       if (TimeCount <= 2)
       {
           UICornersGradient.m_topLeftColor = Color.blue;
           UICornersGradient.m_topRightColor = Color.white;
           UICornersGradient.m_bottomRightColor = Color.cyan;
           UICornersGradient.m_bottomLeftColor = Color.green;
       }

       if (TimeCount <= 1)
       {
           UICornersGradient.m_topLeftColor = Color.blue;
           UICornersGradient.m_topRightColor = Color.cyan;
           UICornersGradient.m_bottomRightColor = Color.white;
           UICornersGradient.m_bottomLeftColor = Color.cyan;
       }
*/
        if (TimeCount <= 4&& TimeCount > 3)
        {
            UICornersGradient.m_topLeftColor = new Color32(248, 168, 133, 0);
            UICornersGradient.m_topRightColor = Color.grey;
            UICornersGradient.m_bottomRightColor = Color.white;
            UICornersGradient.m_bottomLeftColor = Color.cyan;
            UICornersGradient.gameObject.SetActive(false);
            UICornersGradient.gameObject.SetActive(true);
        }
        else if (TimeCount <= 3 && TimeCount > 2)
        {
            UICornersGradient.m_topLeftColor = Color.cyan;
            UICornersGradient.m_topRightColor = Color.blue;
            UICornersGradient.m_bottomRightColor = Color.grey;
            UICornersGradient.m_bottomLeftColor = Color.white;
            UICornersGradient.gameObject.SetActive(false);
            UICornersGradient.gameObject.SetActive(true);
        }
        else if (TimeCount <= 2 && TimeCount > 1)
        {
            UICornersGradient.m_topLeftColor = Color.white;
           UICornersGradient.m_topRightColor = Color.cyan;
           UICornersGradient.m_bottomRightColor = Color.blue;
           UICornersGradient.m_bottomLeftColor = Color.grey;
            UICornersGradient.gameObject.SetActive(false);
            UICornersGradient.gameObject.SetActive(true);
        }
        else if (TimeCount <= 1 && TimeCount > 0)
        {
            UICornersGradient.m_topLeftColor = Color.grey;
            UICornersGradient.m_topRightColor = Color.white;
            UICornersGradient.m_bottomRightColor = Color.cyan;
            UICornersGradient.m_bottomLeftColor = Color.blue;
            UICornersGradient.gameObject.SetActive(false);
            UICornersGradient.gameObject.SetActive(true);
        }

        if (TimeCount <= 0)
        {
            TimeCount = 4;
        }
    }
}
