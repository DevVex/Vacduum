using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static float maxFluff = 100.0f;
    public static float fluffImpactGain = 20.0f;
    public float pointGain = 20.0f;


    public static float currentScore = 0;

    public static float currentFluff;

    public Image fluffBar;
    public Text score;

    private float fluffLossRate = 10.0f;

    public static bool started = true;
    public static bool gameOver = false;
    public static float gameSpeed = 0.6f;
    public static float columnSize = 0.95f;

    public static int highscore;
    public static int currentScoreInt;
    private bool newHighscore = false;

    public GameObject gameOverScreen;

    public CharacterMovement characterMovement;


	// Use this for initialization
	void Start () {
        currentFluff = maxFluff;
        started = true;
        gameOver = false;
        currentScore = 0;
        highscore = PlayerPrefs.GetInt("highscore", highscore);
    }
	
	// Update is called once per frame
	void Update () {

        if (gameOver)
        {
            return;
        }

        currentFluff -= gameSpeed * fluffLossRate * Time.deltaTime;
        currentScore += gameSpeed * pointGain * Time.deltaTime;

        currentScoreInt = (int)Mathf.Round(currentScore);

        if (currentScoreInt > highscore)
        {
            if(highscore > 0 && !newHighscore)
            {
                NewHighScore();
            }
            highscore = currentScoreInt;
            PlayerPrefs.SetInt("highscore", highscore);
        }

        //Update UI
        fluffBar.fillAmount = currentFluff / maxFluff;
        score.text = currentScoreInt.ToString();

        if (currentFluff <= 0)
        {
            GameOver();
        }
	}

    void NewHighScore()
    {
        Debug.Log("New High Score!");
        newHighscore = true;
        // TODO play some effect
    }

    void GameOver()
    {
        gameOver = true;
        Debug.Log("Game Over");
        StartCoroutine("GameOverRoutine");
    }

    public IEnumerator GameOverRoutine()
    {
        characterMovement.Cling();
        yield return new WaitForSeconds(2);
        gameOverScreen.active = true;
    }

    public static void HitObject ()
    {
        CameraShake.Run();
        if (SoundManager.instance.vibrate)
        {
            Handheld.Vibrate();
        }
        currentFluff -= fluffImpactGain;
    }

    public static void HitFluff()
    {
        currentFluff += fluffImpactGain;
        currentScore += fluffImpactGain;
        if (currentFluff > maxFluff)
        {
            currentFluff = maxFluff;
        }
    }
}
