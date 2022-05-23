using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startAnimate : MonoBehaviour
{
    public Animator ani;
    public void play()
    {
        ani.SetTrigger("start");
        ParticleSystem flame = transform.GetChild(0).GetComponent<ParticleSystem>();
        flame.Play();
        
    }
    public void loadSene2()
    {
        SceneManager.LoadScene("StartScene2");
    }
    public void loadNewScene()
    {
        SceneManager.LoadScene("Stadium");
    }
}
