using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {


    private int currentPosition = 0;
    public float moveSize;
    public float stepDelay;
    private float timePassed = 0f;

    // Update is called once per frame
    void Update () {

        //Cant move if the game hasn't started of if you have already lost
        if (!GameManager.started || GameManager.gameOver)
        {
            return;
        }

        timePassed += Time.deltaTime;

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            if(timePassed >= stepDelay)
            {
                timePassed = 0f;
                MoveRight();
            }
        }

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            if (timePassed >= stepDelay)
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
            transform.position = new Vector3(transform.position.x + moveSize, transform.position.y, transform.position.z);
        }
    }

    void MoveLeft()
    {
        if (currentPosition > -2)
        {
            currentPosition--;
            transform.position = new Vector3(transform.position.x - moveSize, transform.position.y, transform.position.z);
        }
    }



}
