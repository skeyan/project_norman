using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{

    [SerializeField]
    float moveSpeed = 4f;

    Vector3 forward, right;

    // Start is called before the first frame update
    void Start()
    {
        // We're aligning the camera vector to the forward vector now
        // Because this simulates more intuitive isometric movement
        forward = Camera.main.transform.forward;
        forward.y = 0; // Ensures y value is set to 0.
        forward = Vector3.Normalize(forward); // Keeps vector's direction but fixes length for motion
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward; // Rotation for right vector
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
            Move();
    }

    void Move()
    {
        // New direction equal to x and y values from input at any given time.
        // d -> 1.0; a -> -1.0
        Vector3 direction = new Vector3(Input.GetAxis("HorizontalKey"), 0, Input.GetAxis("VerticalKey"));
        // Moves in positive or neg direction depending on GetAxis 
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey");
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey");

        // Create a direction our character can now point to 
        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);


        // Since heading is already rotated how we want it to be, we use that instead of regular forward movement
        // The rotation
        transform.forward = heading;
        // Actual movement
        transform.position += rightMovement;
        transform.position += upMovement;
    }
}



