using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballScore : MonoBehaviour
{
    public GameObject ball;
    public bool IsTwoPoint = false; //false => 3���y  true => 2���y
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "twoPointArea")
        {
            IsTwoPoint = true;
            //Debug.Log("twoPoint");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "twoPointArea")
        {
            IsTwoPoint = false;
            //Debug.Log("threePoint");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            ballStatus.statusReset();
            transform.GetChild(0).GetComponent<ParticleSystem>().Stop();
            
        }
        else if(collision.gameObject.tag == "basket")
        {
            transform.GetChild(0).GetComponent<ParticleSystem>().Stop();
        }
    }

}
