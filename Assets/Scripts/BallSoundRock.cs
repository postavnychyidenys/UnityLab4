using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSoundRock : MonoBehaviour
{
    [SerializeField] AudioClip touch;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(touch, transform.position);
    }
}
