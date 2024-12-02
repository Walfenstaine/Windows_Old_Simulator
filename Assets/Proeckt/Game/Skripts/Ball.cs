using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public AudioClip bang, clik;
    void Start()
    {
        Lives.regit.balls += 1;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bort")
        {
            SoundPlayer.regit.Play(bang);
        }
        if (collision.gameObject.tag == "Sphera")
        {
            SoundPlayer.regit.Play(clik);
        }
    }
}
