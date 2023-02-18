using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // The Transform component of the target object that the camera should follow.
    public Transform target;

    // The speed at which the camera should smoothly follow the target.
    public float smoothSpeed = 1f;

    // The offset from the target's position that the camera should maintain.
    public Vector3 offset;
    
    // A reference to the PlayerController component on the player object.
    private PlayerController playerController;

    private void Awake()
    {
        // Get a reference to the PlayerController component on the player object.
        playerController = target.GetComponent<PlayerController>();
    }

    void LateUpdate()
    {
        /*if (playerController.isNight)
        {
            transform.position = new Vector3(0, 28, 0);
        }
        else
        {
            transform.position = new Vector3(0, 0, 0);
        }*/

        // Calculate the desired position for the camera, which is the target's position plus the offset.
        Vector3 desiredPosition = target.position + offset;

        // Interpolate between the current position and the desired position to create a smooth following effect.
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
    
        // Fix the y and z position of the camera to ensure it only follows the target along the x-axis.
        smoothedPosition.y = transform.position.y;
        smoothedPosition.z = transform.position.z;

        // Update the position of the camera.
        transform.position = smoothedPosition;
    }
}
