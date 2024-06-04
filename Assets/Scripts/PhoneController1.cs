using UnityEngine;

public class PhoneController1 : MonoBehaviour
{
    public GameObject baseObject; // Reference to the base object
    public AudioClip ringingSound; // Ringing sound clip

    private AudioSource audioSource;
    private bool isPickedUp = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // Ensure the audio source is not playing initially
        audioSource.Stop();
        
        // Start ringing when the game starts
        StartRinging();
    }

    void Update()
    {
        // Check if the phone is clicked
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hitCollider = Physics2D.OverlapPoint(clickPosition);

            // If the phone is clicked and it's not picked up yet, pick it up
            if (hitCollider != null && hitCollider.gameObject == gameObject && !isPickedUp)
            {
                PickUpPhone();
            }
        }

        // Check if the phone is in contact with the base and stop ringing accordingly
        if (baseObject != null && isPickedUp)
        {
            Collider2D phoneCollider = GetComponent<Collider2D>();
            Collider2D baseCollider = baseObject.GetComponent<Collider2D>();

            // Ensure both colliders are not null before checking for contact
            if (phoneCollider != null && baseCollider != null)
            {
                if (phoneCollider.IsTouching(baseCollider))
                {
                    PutDownPhone();
                }
            }
        }
    }

    void StartRinging()
    {
        // Start playing the ringing sound
        audioSource.clip = ringingSound;
        audioSource.loop = true;
        audioSource.Play();
    }

    void PickUpPhone()
    {
        // Stop playing the ringing sound
        audioSource.Stop();
        isPickedUp = true;
    }

    void PutDownPhone()
    {
        // Start playing the ringing sound again
        audioSource.Play();
        isPickedUp = false;
    }
}
