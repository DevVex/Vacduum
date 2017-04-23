﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour {

    public GameObject pauseScreen;
    public Text score;
    public Text highscore;

	public void StartPause()
    {
        Time.timeScale = 0.0f;
        pauseScreen.active = true;
        score.text = "SCORE: " + GameManager.currentScoreInt.ToString();
        highscore.text = "HIGH SCORE: " + GameManager.highscore.ToString();
    }

    public void Unpause()
    {
        Time.timeScale = 1.0f;
        pauseScreen.active = false;
    }
}