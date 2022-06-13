using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CirclePoint : MonoBehaviour
{
    GameObject[] circlePointArray;
    public GameObject circle;
    public int circleLife;//圈圈的生存秒數
    List<int> randomList;
    int circleIndex;
    float fTime=0f;
    bool isStop = false;

    // Start is called before the first frame update
    void Start()
    {
        System.Random rand = new System.Random(Guid.NewGuid().GetHashCode());
        randomList = new List<int>(Enumerable.Range(0, 11));
        randomList = randomList.OrderBy(num => rand.Next()).ToList<int>();

        circlePointArray  = GameObject.FindGameObjectsWithTag("circlePoint");
        circleIndex = 0;
        showNextCircle();
    }

    // Update is called once per frame
    void Update()
    {
        if (circleIndex == randomList.Count || isStop)
            return;
        if (circleLife > 0)
        {
            fTime += Time.deltaTime; //ftime = ftime + Time.deltaTime
            if (fTime >= 1)
            {
                circleLife--;//countNum = countNum -1 //countNum-=1
                fTime = 0f;
            }
        }
        else
        {
            clearCurrentCircle();
            circleLife = 10;
        }
    }
    
    private void showNextCircle()
    {
        if (circleIndex == randomList.Count || isStop)
            return;
        int randomNum = randomList[circleIndex];
        GameObject circlePoint = circlePointArray[randomNum];
        GameObject child = Instantiate(circle, circlePoint.transform.position, circlePoint.transform.rotation);
        child.transform.parent = circlePoint.transform;
        circleLife = 10;
    }

    public void clearCurrentCircle()
    {
        int randomNum = randomList[circleIndex++];
        circlePointArray[randomNum].SetActive(false);
        showNextCircle();
    }
    public void stop()
    {
        isStop = true;
        clearCurrentCircle();
    }
}
