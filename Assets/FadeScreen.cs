using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeScreen : MonoBehaviour {

    public static Image fadeScreen;
    public static float fadeSpeed = 4f;
    public bool sceneStarting = true;

    void Awake()
    {
        fadeScreen = GetComponent<Image>();
        fadeScreen.rectTransform.localScale = new Vector2(Screen.width, Screen.height);
    }

    void Update()
    {
        if (sceneStarting)
            StartScene();
    }

    void StartScene()
    {
        Debug.Log("Fading to clear");
        FadeToClear();
       
        if (fadeScreen.color.a <= 0.05f)
        {
            fadeScreen.color = Color.clear;
            fadeScreen.enabled = false;
            sceneStarting = false;
        }
    }

    public void LoadScene(int scene)
    {
        Debug.Log("Load Scene " + scene);
        StartCoroutine("LoadSceneRoutine", scene); 
    }

    void FadeToClear()
    {
        // Lerp the colour of the image between itself and transparent.
        fadeScreen.color = Color.Lerp(fadeScreen.color, Color.clear, fadeSpeed * Time.deltaTime);
    }

    void FadeToBlack()
    {
        // Lerp the colour of the image between itself and black.
        fadeScreen.color = Color.Lerp(fadeScreen.color, Color.black, fadeSpeed * Time.deltaTime);
    }

    IEnumerator LoadSceneRoutine(int scene)
    {
        Debug.Log("Load Scene Routine: " + scene);
        fadeScreen.enabled = true;
        do
        {
            // Start fading towards black.
            FadeToBlack();

            // If the screen is almost black...
            if (fadeScreen.color.a >= 0.95f)
            {
                // ... reload the level
                SceneManager.LoadScene(scene);
                yield break;
            }
            else
            {
                yield return null;
            }
        } while (true);
    }
}
