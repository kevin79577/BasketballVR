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
        if (countNum > 0)//���˼ƨ�0�A�N���˼�
        {
            //�ֿn�{�b�L�F�X��
            ftime += Time.deltaTime; //ftime = ftime + Time.deltaTime
            if (ftime >= 1f)//���ֿn�W�L1��
            {
                //�˼�
                countNum--;//countNum = countNum -1 //countNum-=1
                //��ܥX��
                clock.text = $"{countNum/60}:{countNum%60}";
                //�N�ֿn�k�s�A���s�p��U��1��
                ftime = 0f;
            }
        }

    }
}
