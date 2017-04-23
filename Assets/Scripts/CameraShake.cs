using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    public static float shakeDuration;
    public float shakeAmount = 0.008f;
    public float decreaseFactor = 1.0f;
    Vector3 originalPos;

    public static void Run()
    {
        shakeDuration = 0.1f;
    }

    void OnEnable()
    {
        originalPos = transform.localPosition;
    }

    void Update()
    {
        if (shakeDuration > 0)
        {
            transform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = 0f;
            transform.localPosition = originalPos;
        }
    }

}
