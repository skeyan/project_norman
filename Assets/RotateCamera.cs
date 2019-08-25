using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// In charge of rotating the camera on left/right arrow key click, 90 degrees
// Centered around the floor plane
public class RotateCamera : MonoBehaviour
{
    public GameObject targetObject; // Floor plane object
    private float targetAngle = 0f;
        // 0f default for initial camera setup position
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
         * 
         * The rotationAmount being set to 1.5f means that it should rotate at 60fps.
         * Thus, when the key is pressed once, Rotate() will keep activating the respective
         * if statement to decrease or increase targetAngle back to 0 until it has finished
         * rotating.
         *
         * This means that everytime the camera rotates 90 degrees, when it stops, its position is
         * referred to by targetAngle as 0. 
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
