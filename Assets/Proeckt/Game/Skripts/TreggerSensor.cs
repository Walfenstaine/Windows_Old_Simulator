using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms.Impl;
public class TreggerSensor : MonoBehaviour
{
    public AudioClip clip;
    public UnityEvent clic;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Sphera")
        {
            Destroy(collision.gameObject);
            clic.Invoke();
            Lives.regit.BalsTimer();
            SoundPlayer.regit.Play(clip);
        }
        if (collision.tag == "Player")
        {
            Lives.regit.Damag();
            Muwer.rid.Rebort();
        }
    }
}
