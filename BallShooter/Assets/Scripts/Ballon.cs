using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballon : MonoBehaviour
{
    public float speed = 2.0f; // Speed of the left-right movement
    public float distance = 1.0f; // Distance of the left-right movement

    private float initialX; // To store the initial X position of the balloon

    void Start()
    {
        // Store the initial X position
        initialX = transform.position.x;
    }

    void Update()
    {
        // Calculate the new X position using a sine wave
        float newX = initialX + Mathf.Sin(Time.time * speed) * distance;

        // Apply the new position while keeping the Y and Z positions the same
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}
