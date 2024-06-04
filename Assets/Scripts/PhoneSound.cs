using UnityEngine;

public class PhoneSound : MonoBehaviour
{
    public AudioClip pickUpSound; // Sound clip for picking up the phone
    public AudioClip putDownSound; // Sound clip for putting down the phone

    private AudioSource interactionAudioSource;
    private bool isPickedUp = false;
    private PhoneRinging phoneRinging;

    void Start()
    {
        // Get the AudioSource component or add one if not present
        interactionAudioSource = gameObject.AddComponent<AudioSource>();

        // Get the PhoneRinging component
        phoneRinging = GetComponent<PhoneRinging>();
    }

    public void PickUpPhone()
    {
        if (!isPickedUp)
        {
            // Stop the ringing sound
            phoneRinging.StopRinging();

            // Play the pick up sound
            interactionAudioSource.PlayOneShot(pickUpSound);

            // Set the phone as picked up
            isPickedUp = true;
        }
    }

    public void PutDownPhone()
    {
        if (isPickedUp)
        {
            // Play the put down sound
            interactionAudioSource.PlayOneShot(putDownSound);

            // Set the phone as put down
            isPickedUp = false;
        }
    }
}
