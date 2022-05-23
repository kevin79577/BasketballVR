using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public int countNum;
    float ftime;
    public Text clock; 
    // Update is called once per frame
    void Update() 
    {
        if (countNum > 0)//當倒數到0，就不倒數
        {
            //累積現在過了幾秒
            ftime += Time.deltaTime; //ftime = ftime + Time.deltaTime
            if (ftime >= 1f)//當累積超過1秒
            {
                //倒數
                countNum--;//countNum = countNum -1 //countNum-=1
                //顯示出來
                clock.text = $"{countNum}秒倒數";
                //將累積歸零，重新計算下個1秒
                ftime = 0f;
            }
        }

    }
}
