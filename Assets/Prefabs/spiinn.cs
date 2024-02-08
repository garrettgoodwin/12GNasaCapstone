using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiinn : MonoBehaviour
{
    public float minSpeed = 10f; // Minimum rotation speed
    public float maxSpeed = 100f; // Maximum rotation speed
    private float rotationSpeed; // Current rotation speed

    void Start()
    {
        // Set a random rotation speed within the given range
        rotationSpeed = Random.Range(minSpeed, maxSpeed);

        // Randomize the direction of the rotation (clockwise or counterclockwise)
        if (Random.value > 0.5f)
        {
            rotationSpeed = -rotationSpeed;
        }
    }

    void Update()
    {
        // Rotate around the Z axis at the given speed
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
