using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fading : MonoBehaviour {

    public Texture2D fadingTexture;
    public float fadeSpeed = 0.08f;

    private int drawDepth = -1000;
    private float alpha = 1.0f;
    private int fadeDir = -1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnGUI()
    {
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);
    }

    public float BeginFade (int direction)
    {
        fadeDir = direction;
        return fadeSpeed;
    }

    private void OnLevelWasLoaded(int level)
    {
        BeginFade(-1);
    }
}
