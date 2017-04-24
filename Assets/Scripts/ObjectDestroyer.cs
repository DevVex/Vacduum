using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour {

    public AudioSource efxSource;

    private void Start()
    {
        if (!SoundManager.instance.sound)
        {
            efxSource.volume = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Object" || other.tag == "Fluff" || other.tag == "Player"){
            Destroy(other.gameObject);
            efxSource.Play();
        }
    }
}
