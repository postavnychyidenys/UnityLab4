using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSoundGrass : MonoBehaviour
{
    [SerializeField] AudioClip touch;
    private AudioSource audioSource;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.clip = touch;

        audioSource.volume = 1f;

        audioSource.Play();
    }
}
