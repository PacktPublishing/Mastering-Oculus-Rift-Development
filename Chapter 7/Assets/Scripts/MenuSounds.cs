using UnityEngine;
using System.Collections;

public class MenuSounds : MonoBehaviour
{
    [SerializeField] private AudioClip buttonPress;
    [SerializeField] private AudioClip buttonHover;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayPressSound()
    {
        audioSource.clip = buttonPress;
        audioSource.Play();
    }

    public void PlayHoverSound()
    {
        audioSource.clip = buttonHover;
        audioSource.Play();
    }
}
