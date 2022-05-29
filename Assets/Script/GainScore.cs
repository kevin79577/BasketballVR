using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GainScore : MonoBehaviour
{
    public Text score;
    public Text ballCount;
    public AudioSource touchNetAudio;
    public AudioSource horrayAudio;


    private void OnTriggerEnter(Collider collision)
    {
        TotalScore.ballCount1 += 1;
        string scoreString = "";
        if(ballStatus.IsFreeThrow)
        {
            TotalScore.score1 += 1;
            scoreString = "1分球";
        }
        else if (ballStatus.IsTwoPoint)
        {
            TotalScore.score1 += 2;
            scoreString = "2分球";
        }
        else
        {
            TotalScore.score1 += 3;
            scoreString = "3分球";
        }
        transform.GetChild(0).GetComponent<ParticleSystem>().Play();
        transform.GetChild(1).GetComponent<ParticleSystem>().Play();
        ballCount.text = $"{TotalScore.ballCount1}球 ({scoreString})" ;
        score.text = $"得分:{TotalScore.score1}";
        touchNetAudio.Play();
        horrayAudio.Play();
    }

}
