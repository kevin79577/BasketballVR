using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateBall : MonoBehaviour
{
    public GameObject ball;
    float ftime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        ftime += Time.deltaTime;
        if (ftime >= 1f)
        {
            Instantiate(ball, this.transform);
            ftime = 0f;
        }
    }
}
