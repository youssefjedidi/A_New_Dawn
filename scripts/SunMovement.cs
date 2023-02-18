using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunMovement : MonoBehaviour
{
    public float speed = 0f; // Controls the speed of the sun's movement
    public float radiusX = 0f; // Controls the X radius of the sun's circular path
    public float radiusY = 0f; // Controls the Y radius of the sun's circular path

    private float time; // Keeps track of the time elapsed in the movement
    private float x;
    private float y;

    void Update()
    {
        // Increment the time by the delta time multiplied by the speed
        time += Time.deltaTime * speed;

        // Calculate the x and y positions of the sun based on the time and the radius
        x = Mathf.Sin(time) * radiusX;
        y = (Mathf.Cos(time) * radiusY)-(4);

        // Calculate the sun's position based on the camera's position and the calculated x and y values
        Vector3 sunPosition = Camera.main.transform.position + new Vector3(x, y, 0);
        sunPosition.z = transform.position.z; // Keep the z position fixed
        
        // Set the sun's position
        transform.position = sunPosition;
    }
}
