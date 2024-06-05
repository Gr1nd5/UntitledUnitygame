using UnityEngine;
using System.Collections;

public class PhoneSound : MonoBehaviour
{
    public AudioClip pickUpSound;
    public AudioClip putDownSound;
    public float ringDelay = 5f; // Delay before the phone starts ringing again

    private AudioSource interactionAudioSource;
    private bool isPickedUp = false;
    private PhoneRinging phoneRinging;

    void Start()
    {
        interactionAudioSource = gameObject.AddComponent<AudioSource>();
        phoneRinging = GetComponent<PhoneRinging>();
        Debug.Log("PhoneSound: Start - AudioSource and PhoneRinging component set.");
    }

    public void PickUpPhone()
    {
        if (!isPickedUp)
        {
            StopAllCoroutines(); // Stop any existing coroutine to avoid multiple coroutines running
            phoneRinging.StopRinging();
            interactionAudioSource.PlayOneShot(pickUpSound);
            isPickedUp = true;
            Debug.Log("PhoneSound: Phone picked up.");
        }
    }

    public void PutDownPhone()
    {
        if (isPickedUp)
        {
            interactionAudioSource.PlayOneShot(putDownSound);
            StartCoroutine(StartRingingAfterDelay());
            isPickedUp = false;
            Debug.Log("PhoneSound: Phone put down.");
        }
    }

    private IEnumerator StartRingingAfterDelay()
    {
        yield return new WaitForSeconds(ringDelay);
        phoneRinging.StartRinging();
        Debug.Log("PhoneSound: Ringing started after delay.");
    }
}
