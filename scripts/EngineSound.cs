using UnityEngine;

public class EngineSound : MonoBehaviour
/*{
    // The audio source that will play the engine sound
    public AudioSource audioSource;

    // The maximum and minimum pitch values for each gear
    public float[] maxPitches;
    public float[] minPitches;

    // The maximum and minimum speed values for each gear
    public float[] maxSpeeds;
    public float[] minSpeeds;

    // The current gear
    private int currentGear;

    // Update is called once per frame
    void Update()
    {
        // Get the current speed of the game object
        float speed = GetComponent<Rigidbody>().velocity.magnitude;
      

        // Check which gear the car should be in
        int newGear = currentGear;
        for (int i = 0; i < maxSpeeds.Length; i++)
        {
            if (speed > maxSpeeds[i])
            {
                newGear = i + 1;
            }
            else if (speed < minSpeeds[i])
            {
                newGear = i - 1;
                break;
            }
            else
            {
                break;
            }
        }

        // Change to the new gear
        if (newGear != currentGear)
        {
            currentGear = newGear;
            audioSource.pitch = 1.0f;
        }

        // Calculate the pitch value based on the current speed
        float pitch = Mathf.Lerp(minPitches[currentGear], maxPitches[currentGear], (speed - minSpeeds[currentGear]) / (maxSpeeds[currentGear] - minSpeeds[currentGear]));

        // Set the pitch of the audio source
        audioSource.pitch = pitch;
    }
}*/

{
    // AudioSource component to play the engine sound
    public AudioSource engineSound;

    // AudioClip with the engine sound
    public AudioClip engineClip;

    // Speed of the bike
    public float speed;

    // Minimum and maximum pitch values for the engine sound
    public float minPitch = 0.5f;
    public float maxPitch = 2.0f;

    void Start()
    {
        // Set the AudioSource clip to the engine sound and play it
        engineSound.clip = engineClip;
        engineSound.Play();
    }

    void Update()
    {
        speed = GetComponent<Rigidbody>().velocity.magnitude;
        // Calculate the pitch based on the current speed of the bike
        float pitch = Mathf.Lerp(minPitch, maxPitch, speed / 100);
        engineSound.pitch = pitch;
    }
}