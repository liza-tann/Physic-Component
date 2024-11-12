using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float forceSize;
    private Rigidbody rigidbody;
    private Vector3 forceDirection;
    public float clickForce = 500f; // Force applied when the ball is clicked

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        forceDirection = new Vector3(horizontalInput, 0, verticalInput);
        forceDirection.Normalize();
    }

    private void FixedUpdate()
    {
        Vector3 force = forceDirection * forceSize;
        rigidbody.AddForce(force);
    }

    private void OnMouseDown()
    {
        // Apply a forward force when the ball is clicked
        Vector3 clickForceDirection = transform.forward * clickForce;
        rigidbody.AddForce(clickForceDirection);
    }
}
