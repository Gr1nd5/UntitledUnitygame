using UnityEngine;

public class PhoneRinging : MonoBehaviour
{
    public GameObject baseObject; // Reference to the base object
    public AudioClip ringingSound; // Ringing sound clip

    private AudioSource ringingAudioSource;
    private bool isOnBase = true;
    private float timeOnBase = 0f;
    private float ringDelay = 30f; // Time delay in seconds to start ringing

    void Start()
    {
        // Get the AudioSource component or add one if not present
        ringingAudioSource = gameObject.AddComponent<AudioSource>();

        // Configure the ringing audio source
        ringingAudioSource.clip = ringingSound;
        ringingAudioSource.loop = true;

        // Start the ringing sound initially
        ringingAudioSource.Play();
    }

    void Update()
    {
        Collider2D phoneCollider = GetComponent<Collider2D>();
        Collider2D baseCollider = baseObject.GetComponent<Collider2D>();

        // Check if the phone is in contact with the base
        if (phoneCollider != null && baseCollider != null)
        {
            if (phoneCollider.IsTouching(baseCollider))
            {
                if (!isOnBase)
                {
                    isOnBase = true;
                    timeOnBase = 0f; // Reset the timer when the phone is placed back on the base
                }
                else
                {
                    timeOnBase += Time.deltaTime;
                    if (timeOnBase >= ringDelay && !ringingAudioSource.isPlaying)
                    {
                        ringingAudioSource.Play();
                    }
                }
            }
            else
            {
                isOnBase = false;
                ringingAudioSource.Stop();
            }
        }
    }

    public void StopRinging()
    {
        ringingAudioSource.Stop();
    }
}
