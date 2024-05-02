using UnityEngine;

public class PhoneController : MonoBehaviour
{
    // Define the original position, target position, original rotation, and target rotation for the phone
    private Vector3 originalPosition;
    public Vector3 targetPosition;
    private Quaternion originalRotation;
    public Quaternion targetRotation;

    // Variable to track whether the phone is currently in its original position and rotation
    private bool isAtOriginalPosition = true;

    void Start()
    {
        // Store the original position and rotation of the phone
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    void OnMouseDown()
    {
        // Toggle between original position and target position, original rotation and target rotation
        if (isAtOriginalPosition)
        {
            // Move the phone to the target position
            transform.position = targetPosition;
            // Rotate the phone to the target rotation
            transform.rotation = targetRotation;
        }
        else
        {
            // Move the phone back to its original position
            transform.position = originalPosition;
            // Rotate the phone back to its original rotation
            transform.rotation = originalRotation;
        }

        // Update the state
        isAtOriginalPosition = !isAtOriginalPosition;
    }
}
