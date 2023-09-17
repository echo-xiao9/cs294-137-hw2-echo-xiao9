using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Speed at which the camera moves

    void Update()
    {
        Vector3 moveDirection = Vector3.zero;

        // Check for WASD input and adjust the moveDirection accordingly
        if (Input.GetKey(KeyCode.W))
        {
            moveDirection += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection += Vector3.back;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection += Vector3.right;
        }

        // Normalize the moveDirection to ensure consistent movement speed in all directions
        moveDirection.Normalize();

        // Move the camera
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
    }
}
