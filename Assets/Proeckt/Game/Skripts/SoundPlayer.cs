using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public AudioSource sors;
    public static SoundPlayer regit { get; set; }
    void Awake()
    {
        if (regit == null)
        {
            regit = this;
        }
        else
        {
            Destroy(this);
        }
    }
    void OnDestroy()
    {
        regit = null;
    }
    public void Play(AudioClip clip)
    {
        sors.PlayOneShot(clip);
    }
}
