using UnityEngine;
using System.Collections;

public class FootstepEmitter : MonoBehaviour
{
    [SerializeField] private AudioClip[] footstepClips;
    private AudioSource audioSource;
    private float timeSinceLastStep = 0;
    private float timeBetweenSteps = 0.5f;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void PlayFootstepSound()
    {
        int randomIndex = Random.Range(0, footstepClips.Length - 1);
        audioSource.clip = footstepClips[randomIndex];
        audioSource.Play();
    }

    private void UpdateStepTimer()
    {
        timeSinceLastStep += Time.deltaTime;
        if (timeSinceLastStep > timeBetweenSteps)
        {
            timeSinceLastStep = 0;
            PlayFootstepSound();
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
	    {
	        UpdateStepTimer();
	    }
	}
}
