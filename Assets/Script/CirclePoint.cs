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
    int circleIndex=0;
    float fTime=0f;
    bool isStop = false;
    public int circleNum;
    List<GameObject> tempObj = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        System.Random rand = new System.Random(Guid.NewGuid().GetHashCode());
        randomList = new List<int>(Enumerable.Range(0, 11));
        randomList = randomList.OrderBy(num => rand.Next()).ToList<int>();

        circlePointArray  = GameObject.FindGameObjectsWithTag("circlePoint");
        for (int i = 0; i < circleNum; i++)
        {
            showNextCircle(circleIndex++);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isStop)
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
            clearAllCurrentCircle();
            circleLife = 10;
        }
    }
    
    private void showNextCircle(int index)
    {
        if (isStop)
            return;
        int randomNum = randomList[index];
        GameObject circlePoint = circlePointArray[randomNum];
        circlePoint.SetActive(true);
        GameObject child = Instantiate(circle, circlePoint.transform.position, circlePoint.transform.rotation);
        child.transform.parent = circlePoint.transform;
        circleLife = 10;
        tempObj.Add(circlePoint);
    }

    public void clearAllCurrentCircle()
    {
        int randomNum = randomList[circleIndex];
        foreach(GameObject temp in tempObj)
        {
            temp.SetActive(false);
        }
        tempObj.Clear();
        for (int i = 0; i < circleNum; i++)
        {
            circleIndex = circleIndex % circlePointArray.Length;
            showNextCircle(circleIndex++);
        }
    }
    public void stop()
    {
        isStop = true;
        clearAllCurrentCircle();
    }
}
