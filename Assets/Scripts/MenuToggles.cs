using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuToggles : MonoBehaviour {

    public Toggle sound;
    public Toggle vibrate;

	// Use this for initialization
	void Start () {
        sound.isOn = SoundManager.instance.sound;
        vibrate.isOn = SoundManager.instance.vibrate;

        sound.onValueChanged.AddListener(SoundManager.instance.SoundToggle);
        vibrate.onValueChanged.AddListener(SoundManager.instance.VibrationToggle);
    }
	
}
