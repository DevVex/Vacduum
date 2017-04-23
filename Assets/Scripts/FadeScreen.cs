using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeScreen : MonoBehaviour {

    public Image fadeScreen;
    public static float fadeSpeed = 4f;
    public bool sceneStarting = true;

    void Update()
    {
        if (sceneStarting)
            StartScene();
    }

    void StartScene()
    {
        Debug.Log("Fading to clear");
        fadeScreen.enabled = true;
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

    public void ReloadCurrentScene()
    {
        StartCoroutine("LoadSceneRoutine", SceneManager.GetActiveScene().buildIndex);
    }

    void FadeToClear()
    {
        fadeScreen.color = Color.Lerp(fadeScreen.color, Color.clear, fadeSpeed * Time.deltaTime);
    }

    void FadeToBlack()
    {
        fadeScreen.color = Color.Lerp(fadeScreen.color, Color.black, fadeSpeed * Time.deltaTime);
    }

    IEnumerator LoadSceneRoutine(int scene)
    {
        fadeScreen.enabled = true;
        do
        {
            FadeToBlack();
            
            if (fadeScreen.color.a >= 0.95f)
            {
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
