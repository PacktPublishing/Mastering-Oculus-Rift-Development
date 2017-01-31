using UnityEngine;
using System.Collections;

public class ProjectileSounds : MonoBehaviour
{
    [SerializeField] private AudioClip bumpClip;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if(audioSource.clip != bumpClip)
        {
            audioSource.clip = bumpClip;
        }

        audioSource.Play();
    }
}
