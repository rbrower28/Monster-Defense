using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{

    // draws the text boxes for score and high score
    [SerializeField] Text scoreCount;
    [SerializeField] Text highScore;

    // prepares these to be set and used in AddScore()
    [SerializeField] int score;
    [SerializeField] int high;


    public void AddScore(int scoreAdd)
    {
        // pulls the score and high score from whatever they currently are on screen
        score = Int32.Parse(scoreCount.text.ToString());
        high = Int32.Parse(highScore.text.ToString());
        
        // add 1 to the score and resets the current score on screen
        score += scoreAdd;
        scoreCount.text = score.ToString();

        // given that the score is higher than the high score, updates to match
        // if the score hasn't reached the high score, does nothing
        if (score >= high)
        {
            highScore.text = score.ToString();
        }
    }
}
