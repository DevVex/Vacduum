using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

    public Text highscoreText;
    private int highscore;

	// Use this for initialization
	void Start () {
        highscore = PlayerPrefs.GetInt("highscore", highscore);
        highscoreText.text = "High Score: " + highscore;
    }
}
