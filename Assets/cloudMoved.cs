using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudMoved : MonoBehaviour
{
    public float modeSpeed = 5f;
    public float accelerationRate = 0.5f;
    public float deadSone = -45f;

    private float currentSpeed;
    void Start()
    {
        currentSpeed = modeSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);

        if (transform.position.x < deadSone)
        {
            Destroy(gameObject);
        }

        currentSpeed += accelerationRate * Time.deltaTime;
    }
}
