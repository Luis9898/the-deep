using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHandler : MonoBehaviour {
    public AudioClip shoot;
    public AudioClip death;
    public AudioClip pup;
    public AudioClip pain;
    public AudioClip squiddeath;
    public AudioClip eeldeath;
    public AudioClip urchindeath;
    public AudioClip key;
    public AudioClip door;
    private AudioSource source;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;

    // Use this for initialization
    void Start () {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void playSound (int c) {
        if (c == 0)
        {
            float vol = Random.Range(volLowRange, volHighRange);
            source.PlayOneShot(shoot, vol);
        }
        else if (c == 1)
        {
            source.PlayOneShot(death, 1.0f);
        }
        else if (c == 2)
        {
            source.PlayOneShot(pup, 1.0f);
        }
        else if (c == 3)
        {
            source.PlayOneShot(pain, 1.0f);
        }
        else if (c == 4)
        {
            source.PlayOneShot(squiddeath, 0.5f);
        }
        else if (c == 5)
        {
            source.PlayOneShot(eeldeath, 0.5f);
        }
        else if (c == 6)
        {
            source.PlayOneShot(urchindeath, 0.5f);
        }
        else if (c == 7)
        {
            source.PlayOneShot(key, 1.0f);
        }
        else if (c == 8)
        {
            source.PlayOneShot(door, 1.0f);
        }
    }
}