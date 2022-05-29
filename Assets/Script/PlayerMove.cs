using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject ball;
    Rigidbody ballRid ;
    public GameObject basket;
    public GameObject freeThrowPoint;
    ParticleSystem flameBall;
    
    public int jumpForce;
    public bool IsTwoPoint = false;
    bool IsFreeThrow = false;

    // Start is called before the first frame update
    void Start()
    {
        ballRid = ball.GetComponent<Rigidbody>();
        flameBall = ball.transform.GetChild(0).GetComponent<ParticleSystem>();
    }

    //�i�J2���y�ϰ� => 2���y
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "twoPointArea")
        {
            IsTwoPoint = true;
            Debug.Log("enter twoPoint area");
        }
        else if (other.gameObject.tag =="circlePoint")
        {
            ballStatus.circlePoint = other.gameObject.transform.parent.gameObject;
        }
    }
    //���}2���y�ϰ� => 3���y
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "twoPointArea")
        {
            IsTwoPoint = false;
            Debug.Log("exit twoPoint area");
        }
        else if (other.gameObject.tag =="circlePoint")
        {
            ballStatus.circlePoint = null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //���ʪ��a��m
            transform.position -= new Vector3(.1f, 0, 0);
            //���ʲy����m
            //transform.GetChild(0) ���]�w�y����l��m
            ball.transform.position = transform.GetChild(0).position;
            ball.transform.rotation = new Quaternion(0,0,0,0);
            ballRid.velocity = Vector3.zero;
            
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(.1f, 0, 0);
            ball.transform.position = transform.GetChild(0).position;
            ball.transform.rotation = new Quaternion(0,0,0,0);
            ballRid.velocity = Vector3.zero;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position -= new Vector3(0, 0, .1f);
            ball.transform.position = transform.GetChild(0).position;
            ball.transform.rotation = new Quaternion(0,0,0,0);
            ballRid.velocity = Vector3.zero;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0, 0, 0.1f);
            ball.transform.position = transform.GetChild(0).position;
            ball.transform.rotation = new Quaternion(0,0,0,0);
            ballRid.velocity = Vector3.zero;
        }
        else if(Input.GetKey(KeyCode.RightControl))
        {
            transform.position = freeThrowPoint.transform.position;
            ball.transform.position = transform.GetChild(0).position;
            ball.transform.rotation = new Quaternion(0,0,0,0);
            ballRid.velocity = Vector3.zero;
            IsFreeThrow  = true;
        }
        else if(Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody rig = ball.GetComponent<Rigidbody>();
            Vector3 diff = basket.transform.position - ball.transform.position;
            Vector3 dir = diff.normalized + new Vector3(0,2,0);
            if(ballStatus.circlePoint != null)
                flameBall.Play();

            ballStatus.IsTwoPoint = IsTwoPoint;
            ballStatus.IsFreeThrow = IsFreeThrow;
            if(IsFreeThrow)
                rig.AddForce(dir * jumpForce*5/6);
            else if (IsTwoPoint)
                rig.AddForce(dir * jumpForce*5/6);
            else
                rig.AddForce(dir * jumpForce*14/15);
        }
        
    }
}
