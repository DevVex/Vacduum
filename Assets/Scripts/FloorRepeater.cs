using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorRepeater : MonoBehaviour {

    public static bool moving = true;

    MeshRenderer meshRenderer;
    Material material;
    Vector2 offset;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        material = meshRenderer.material;
    }

    // Update is called once per frame
    void Update () {
        if(GameManager.started && !GameManager.gameOver)
        {
            offset = material.mainTextureOffset;
            offset.y += GameManager.gameSpeed * Time.deltaTime;
            material.mainTextureOffset = offset;
        }
	}
}
