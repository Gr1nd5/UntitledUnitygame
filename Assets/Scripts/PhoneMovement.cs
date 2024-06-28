using UnityEngine;

public class PhoneMovement : MonoBehaviour
{
    private Vector3 originalPosition;
    public Vector3 targetPosition;
    private Quaternion originalRotation;
    public Quaternion targetRotation;

    private bool isAtOriginalPosition = true;
    private PhoneSound phoneSound;

    void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
        phoneSound = GetComponent<PhoneSound>();
        Debug.Log("PhoneMovement: Start - Positions and rotations set.");
    }

    void OnMouseDown()
    {
        if (isAtOriginalPosition)
        {
            transform.position = targetPosition;
            transform.rotation = targetRotation;
            phoneSound.PickUpPhone();
            Debug.Log("PhoneMovement: Phone moved to target position.");
        }
        else
        {
            transform.position = originalPosition;
            transform.rotation = originalRotation;
            phoneSound.PutDownPhone();
            Debug.Log("PhoneMovement: Phone moved back to original position.");
        }
        isAtOriginalPosition = !isAtOriginalPosition;
    }
}
