using UnityEngine;

public class PhoneMovement : MonoBehaviour
{
    // Define the original position, target position, original rotation, and target rotation for the phone
    private Vector3 originalPosition;
    public Vector3 targetPosition;
    private Quaternion originalRotation;
    public Quaternion targetRotation;

    // Variable to track whether the phone is currently in its original position and rotation
    private bool isAtOriginalPosition = true;

    private PhoneSound phoneSound;

    void Start()
    {
        // Store the original position and rotation of the phone
        originalPosition = transform.position;
        originalRotation = transform.rotation;

        // Get the PhoneSound component
        phoneSound = GetComponent<PhoneSound>();
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

            // Play the pick-up sound
            phoneSound.PickUpPhone();
        }
        else
        {
            // Move the phone back to its original position
            transform.position = originalPosition;
            // Rotate the phone back to its original rotation
            transform.rotation = originalRotation;

            // Play the put-down sound
            phoneSound.PutDownPhone();
        }

        // Update the state
        isAtOriginalPosition = !isAtOriginalPosition;
    }
}
