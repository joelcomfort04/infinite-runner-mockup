using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour
{

    public Text scoreUI;
    public float score = 0f;
    public GameObject player;


    void FixedUpdate()
    {
        float curScore = score;
        score = getCurScore();
        if (curScore > score) { score = curScore; }
        
        scoreUI.text = "Score: " + Mathf.Round(score); 
    }

    float getCurScore()
    {
        float newScore = player.transform.position.x;
        if (newScore < 0) { newScore = 0f; }
        return newScore;
    }
}
