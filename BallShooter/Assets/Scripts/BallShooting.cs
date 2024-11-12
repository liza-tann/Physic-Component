using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShooting : MonoBehaviour
{
    public float Force;

    void OnMouseDown()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.right * Force, ForceMode.Impulse);
    }

}
