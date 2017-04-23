using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour {

    private float offset = 15.0f;
	
	// Update is called once per frame
	void Update () {

        if (!GameManager.started || GameManager.gameOver)
        {
            return;
        }

        transform.position = new Vector3(transform.position.x, transform.position.y - (GameManager.gameSpeed * Time.deltaTime * offset), transform.position.z);
	}
}
