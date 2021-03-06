﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {


    private int currentPosition = 0;
    public float stepDelay;
    private float timePassed = 0f;
    private float timePassedLook = 0f;

    private float lookTime;

    public AudioClip moveSound1;
    public AudioClip moveSound2;
    public Animator anim;

    private void Start()
    {
        SetRandomLookTime();
    }

    // Update is called once per frame
    void Update () {

        //Cant move if the game hasn't started of if you have already lost
        if (!GameManager.started || GameManager.gameOver)
        {
            return;
        }

        timePassed += Time.deltaTime;
        timePassedLook += Time.deltaTime;

        if (timePassedLook >= lookTime)
        {
            LookBack();
            timePassedLook = 0.0f;
            SetRandomLookTime();
        }

        if(timePassed >= stepDelay)
        {
            if (Input.touchCount == 1)
            {
                var touch = Input.touches[0];
                if (touch.position.x < Screen.width / 2 && touch.position.y < (Screen.height - Screen.height/10))
                {
                    timePassed = 0f;
                    MoveLeft();
                }
                else if (touch.position.x > Screen.width / 2 && touch.position.y < (Screen.height - Screen.height / 10))
                {
                    timePassed = 0f;
                    MoveRight();
                }
            }

            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                timePassed = 0f;
                MoveRight();
            }
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                timePassed = 0f;
                MoveLeft();
            }
        }
    }

    void MoveRight()
    {
        if(currentPosition < 2)
        {
            currentPosition++;
            transform.position = new Vector3(transform.position.x + GameManager.columnSize, transform.position.y, transform.position.z);
            SoundManager.instance.RandomizeSfx(moveSound1, moveSound2);
        }
    }

    void MoveLeft()
    {
        if (currentPosition > -2)
        {
            currentPosition--;
            transform.position = new Vector3(transform.position.x - GameManager.columnSize, transform.position.y, transform.position.z);
            SoundManager.instance.RandomizeSfx(moveSound1, moveSound2);
        }
    }

    void SetRandomLookTime()
    {
        lookTime = Random.Range(10.0f, 20.0f);
    }

    void LookBack()
    {
        anim.SetTrigger("look");
    }

    public void Cling()
    {
        anim.applyRootMotion = false;
        anim.SetTrigger("cling");
    }



}
