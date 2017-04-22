using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollider : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);

        if (other.tag == "Object")
        {
            GameManager.HitObject();
        } else if(other.tag == "Fluff")
        {
            Destroy(other.gameObject);
            GameManager.HitFluff();
        }
    }
}
