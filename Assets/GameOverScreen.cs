using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour {

    public Text score;
    public Text highscore;

    // Use this for initialization
    void Start () {
        score.text = "SCORE: " + GameManager.currentScoreInt.ToString();
        highscore.text = "HIGH SCORE: " + GameManager.highscore.ToString();
    }

}
