using UnityEngine;

public class RotateObject : MonoBehaviour
{
    // Variable to set the rotation speed
    public float rotationSpeed = 100f;

    void Update()
    {
        // Rotate the object around the Z-axis
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
