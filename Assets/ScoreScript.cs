using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int score;
    public Text scoreText;
    void Start()
    {
        
    }

    // Update is called once per frame
   public void Score(int scoreValue)
    {
        score = score + scoreValue;
        scoreText.text = "Score: " + score;
    }
}
