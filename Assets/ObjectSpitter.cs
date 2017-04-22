using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpitter : MonoBehaviour {

    public GameObject[] objects;
    public GameObject[] bunnies;

    private float timePassedObject = 0f;
    private float timePassedBunny = 0f;
    private float randomObjectTime;
    private float randomBunnyTime;

    private void Start()
    {
        SetRandomObjectTime();
        SetRandomBunnyTime();
    }

    // Update is called once per frame
    void Update () {


        timePassedObject += Time.deltaTime;
        timePassedBunny += Time.deltaTime;


        if (timePassedObject > randomObjectTime)
        {
            timePassedObject = 0f;
            SetRandomObjectTime();
            SpawnRandomObject();
        }

        if (timePassedBunny > randomBunnyTime)
        {
            timePassedBunny = 0f;
            SetRandomBunnyTime();
            SpawnRandomBunny();
        }
    }

    void SetRandomObjectTime()
    {
        randomObjectTime = Random.Range(2.0f, 6.0f);
    }

    void SetRandomBunnyTime()
    {
        randomBunnyTime = Random.Range(5.0f, 10.0f);
    }

    GameObject GetRandomObject()
    {
        int randomInt = (int) Mathf.Round(Random.Range(0f, objects.Length - 1));
        return objects[randomInt];
    }

    GameObject GetRandomBunny()
    {
        int randomInt = (int)Mathf.Round(Random.Range(0f, bunnies.Length - 1));
        return bunnies[randomInt];
    }

    void SpawnRandomObject()
    {
        GameObject randomObject = GetRandomObject();
        int column = (int) Mathf.Round(Random.Range(-2.0f, 2.0f));

        Debug.Log("column obj: " + column);

        Instantiate(randomObject, new Vector3(column * GameManager.columnSize, transform.position.y, 0.0f), Quaternion.identity, null);
    }

    void SpawnRandomBunny()
    {
        GameObject randomObject = GetRandomBunny();
        int column = (int)Mathf.Round(Random.Range(-2.0f, 2.0f));

        Debug.Log("column bun: " + column);

        Instantiate(randomObject, new Vector3(column * GameManager.columnSize, transform.position.y, 0.0f), Quaternion.identity, null);
    }
}
