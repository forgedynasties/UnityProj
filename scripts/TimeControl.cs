using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeControl : MonoBehaviour
{
    // The target time scale for slow motion
    public float slowMotionScale = 0.2f;
    // The duration of the slow motion effect
    public float slowMotionDuration = 2.0f;
    // The target pitch for slow motion
    public float slowMotionPitch = 0.5f;
    public GameObject bike;
    public GameObject slomoButton;

    // A coroutine that slows down time
    private IEnumerator slowMotionCoroutine;

    // Update is called once per frame
    void Update()
    {
        // Update code goes here
       
    }

    // A function that starts the slow motion effect
    public void StartSlowMotion()
    {
        // Start the slow motion coroutine
        slowMotionCoroutine = SlowMotion();
        StartCoroutine(slowMotionCoroutine);
        StartSlowMotion();
        bike.GetComponent<BikeController>().sideForce *= 3;


    }

    // A coroutine that slows down time
    IEnumerator SlowMotion()
    {
        slomoButton.GetComponent<SlomoButton>().decSlomo();
        // Set the time scale to the slow motion scale
        Time.timeScale = slowMotionScale;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;

        // Set the pitch of all audio sources to the slow motion pitch
        SetAudioPitch(slowMotionPitch);

        // Wait for the duration of the slow motion effect
        yield return new WaitForSecondsRealtime(slowMotionDuration);

        // Set the time scale back to normal
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;

        // Set the pitch of all audio sources back to normal
        SetAudioPitch(1.0f);
        bike.GetComponent<EngineSound>().enabled = true;
        bike.GetComponent<BikeController>().sideForce /= 3;
        


    }

    // A function that sets the pitch of all audio sources in the scene
    void SetAudioPitch(float pitch)
    {
        // Get all audio sources in the scene
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();
        bike.GetComponent<EngineSound>().enabled = false;

        // Set the pitch of each audio source
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.pitch = pitch;
        }
        
    }
}
