using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudSpawner : MonoBehaviour
{
    public GameObject Cloud;
    public float spawnRate = 2;
    public float timer = 0;
    public float heightOffSet = 10;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            spawnPipe();
            timer = 0;
        }

    }

    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffSet;
        float highestPoint = transform.position.y + heightOffSet;

        Instantiate(Cloud, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 1), transform.rotation);
    }
}
