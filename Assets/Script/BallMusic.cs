using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMusic : MonoBehaviour
{
    public AudioSource touchGroudAudio;
    public AudioSource basketAudio;
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "floor")
        {
            touchGroudAudio.Play();
        }
        else if(collision.gameObject.tag == "basket")
        {
            basketAudio.Play();
        }
    }

}
