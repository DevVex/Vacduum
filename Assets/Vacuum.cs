using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vacuum : MonoBehaviour {

    public AudioSource efxSource;

    float defaultVolume;

    private void Start()
    {
        defaultVolume = efxSource.volume;
        if (!SoundManager.instance.sound)
        {
            efxSource.volume = 0;
        }
    }

    private void Update()
    {
        if (!SoundManager.instance.sound)
        {
            return;
        }

        if (Pause.paused || GameManager.gameOver)
        {
            efxSource.volume = 0;
        }
        else
        {
            efxSource.volume = defaultVolume;
        }
    }
}
