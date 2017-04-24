using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollider : MonoBehaviour {

    public AudioClip objectHitSound;
    public AudioClip fluffHitSound;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Object")
        {
            GameManager.HitObject();
            SoundManager.instance.RandomizeSfx(objectHitSound);

        } else if(other.tag == "Fluff")
        {
            Destroy(other.gameObject);
            GameManager.HitFluff();
            SoundManager.instance.RandomizeSfx(fluffHitSound);
        }
    }
}
