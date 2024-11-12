using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private HingeJoint hingeJoint;
    private bool isDoorOpen = false; // Track the state of the door

    void Start()
    {
        hingeJoint = GetComponent<HingeJoint>();
        hingeJoint.useMotor = true;

        // Set initial motor settings
        JointMotor motor = hingeJoint.motor;
        motor.force = 100;
        motor.targetVelocity = 50; // Speed for opening the door
        hingeJoint.motor = motor;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OpenDoor();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CloseDoor();
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Check for left mouse button click
        {
            // Raycast from the camera to detect if the door was clicked
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform) // Check if the clicked object is this door
                {
                    if (isDoorOpen)
                    {
                        CloseDoor();
                    }
                    else
                    {
                        OpenDoor();
                    }
                }
            }
        }
    }

    private void OpenDoor()
    {
        JointMotor motor = hingeJoint.motor;
        motor.targetVelocity = 50; // Open the door
        hingeJoint.motor = motor;
        isDoorOpen = true;
    }

    private void CloseDoor()
    {
        JointMotor motor = hingeJoint.motor;
        motor.targetVelocity = -50; // Close the door
        hingeJoint.motor = motor;
        isDoorOpen = false;
    }
}
