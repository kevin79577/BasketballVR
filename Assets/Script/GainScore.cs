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
    public GameObject circlePointCollection;


    private void OnTriggerEnter(Collider collision)
    {
        TotalScore.ballCount1 += 1;
        string scoreString = "";
        if(ballStatus.IsFreeThrow)
        {
            TotalScore.score1 += 1;
            scoreString = "1point";
        }
        else if (ballStatus.IsTwoPoint)
        {
            TotalScore.score1 += 2;
            scoreString = "2point";
        }
        else
        {
            TotalScore.score1 += 3;
            scoreString = "3point";
        }
        transform.GetChild(0).GetComponent<ParticleSystem>().Play();
        transform.GetChild(1).GetComponent<ParticleSystem>().Play();
        ballCount.text = $"Counts {TotalScore.ballCount1} ({scoreString})" ;
        score.text = $"Scores {TotalScore.score1}";
        touchNetAudio.Play();
        horrayAudio.Play();

        CirclePoint script = circlePointCollection.GetComponent<CirclePoint>();
        script.clearCurrentCircle();

    }

}
