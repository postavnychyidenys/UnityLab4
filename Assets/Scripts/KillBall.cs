using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBall : MonoBehaviour
{
    [SerializeField] AudioClip die;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        die = IncreaseVolume(die, 4.0f);
        AudioSource.PlayClipAtPoint(die, transform.position);
        Destroy(collision.gameObject, 0.3f);
    }

    private AudioClip IncreaseVolume(AudioClip clip, float factor)
    {
        float[] data = new float[clip.samples * clip.channels];
        clip.GetData(data, 0);

        for (int i = 0; i < data.Length; i++)
        {
            data[i] *= factor;
        }

        clip.SetData(data, 0);
        return clip;
    }
}
