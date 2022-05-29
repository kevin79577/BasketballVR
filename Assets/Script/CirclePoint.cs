using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclePoint : MonoBehaviour
{
    GameObject[] circlePointArray;
    public GameObject circle;
    public int generateTime;//產生下個圈的秒數
    public int circleLife;//圈圈的生存秒數
    private float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        circlePointArray  = GameObject.FindGameObjectsWithTag("circlePoint");
        foreach(GameObject circlePoint in circlePointArray)
        {
            //Debug.Log("ok");
            GameObject child = Instantiate(circle, circlePoint.transform.position, circlePoint.transform.rotation);
            child.transform.parent = circlePoint.transform;
        }   
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime > 0)
        {
            currentTime += Time.deltaTime; //ftime = ftime + Time.deltaTime
            if (currentTime >= circleLife)
            {
                circleLife--;//countNum = countNum -1 //countNum-=1
            }
        }
    }
}
