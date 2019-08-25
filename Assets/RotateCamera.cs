using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// In charge of rotating the camera on left/right arrow key click, 90 degrees
// Centered around the floor plane
public class RotateCamera : MonoBehaviour
{
    public GameObject targetObject; // Floor plane object
    private float targetAngle = 0f; // 0f default for initial camera setup position
    const float rotationAmount = 1.5f;
    public float rDistance = 1.0f;
    public float rSpeed = 1.0f;

    // Update is called once per frame
    void Update()
    {

        // Trigger functions if Rotate is requested
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            targetAngle -= 90.0f;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            targetAngle += 90.0f;
        }

        if (targetAngle != 0)
        {
            Rotate();
        }

    }

    protected void Rotate()
    {

        /* If a left/right key has been pressed,
         * Rotate the camera around the center of the targetObject (the Floor plane)
         * A negative 90 degree or positive 90 degree depending on direction
         * And account for the change in targetAngle.
         * That way, even in that new position, other additional rotations
         *
         */
        if (targetAngle > 0)
        {
            transform.RotateAround(targetObject.transform.position, Vector3.up, -rotationAmount);
            targetAngle -= rotationAmount;
        }
        else if (targetAngle < 0)
        {
            transform.RotateAround(targetObject.transform.position, Vector3.up, rotationAmount);
            targetAngle += rotationAmount;
        }

    }
}
