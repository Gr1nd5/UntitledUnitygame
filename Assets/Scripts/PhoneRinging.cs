using UnityEngine;

public class PhoneRinging : MonoBehaviour
{
    public AudioClip ringingSound; // Ringing sound clip

    private AudioSource ringingAudioSource;

    void Start()
    {
        ringingAudioSource = gameObject.AddComponent<AudioSource>();
        ringingAudioSource.clip = ringingSound;
        ringingAudioSource.loop = true;
        ringingAudioSource.volume = 1.0f; // Ensure volume is set

        Debug.Log("PhoneRinging: Start - AudioSource and clip set.");
    }

    public void StartRinging()
    {
        if (!ringingAudioSource.isPlaying)
        {
            ringingAudioSource.Play();
            Debug.Log("PhoneRinging: Phone started ringing.");
        }
    }

    public void StopRinging()
    {
        if (ringingAudioSource.isPlaying)
        {
            ringingAudioSource.Stop();
            Debug.Log("PhoneRinging: Phone stopped ringing.");
        }
    }
}
