using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public AudioClip jump, coin;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Play(string clip)
    {
        if (clip.Equals("jump")) {
            audioSource.PlayOneShot(jump);
        } else if (clip.Equals("coin")) {
            audioSource.PlayOneShot(coin);
        }
    }
}
