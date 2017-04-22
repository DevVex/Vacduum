using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public float maxFluff = 100.0f;
    public static float fluffImpactGain = 20.0f;
    public float pointGain = 5.0f;


    private float currentScore = 0;

    public static float currentFluff;

    public Image fluffBar;
    public Text score;

    public static bool started = true;
    public static bool gameOver = false;
    public static float gameSpeed = 0.4f;


	// Use this for initialization
	void Start () {
        currentFluff = maxFluff;
        started = true;
    }
	
	// Update is called once per frame
	void Update () {

        if (gameOver)
        {
            return;
        }

        currentFluff -= gameSpeed * Time.deltaTime;
        currentScore += gameSpeed * pointGain * Time.deltaTime;

        //Update UI
        fluffBar.fillAmount = currentFluff / maxFluff;
        score.text = Mathf.Round(currentScore).ToString();

        if (currentFluff <= 0)
        {
            GameOver();
        }
	}

    void GameOver()
    {
        gameOver = true;
        Debug.Log("Game Over");
        // TODO show score
    }

    public static void HitObject ()
    {
        currentFluff -= fluffImpactGain;
    }

    public static void MergedBunny()
    {
        currentFluff += fluffImpactGain;
    }
}
