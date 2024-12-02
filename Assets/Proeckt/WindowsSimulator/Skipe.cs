using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Skipe : MonoBehaviour
{
    public Image screen;
    public Animator anim;
    public UnityEvent<bool> dozvon;
    float timer = 0;
    bool onscreen = false;
    public void Onscreen(Sprite s) 
    {
        screen.sprite = s;
        timer = Time.time + Random.Range(10, 15);
        onscreen = true;
    }
    public void OffScreen() 
    {
        anim.SetBool("Work", false);
        onscreen = false;
    }
    public void FixedUpdate()
    {
        if (onscreen) 
        {
            if (Time.time > timer)
            {
                anim.SetBool("Work", true);
            }
        }
    }
}
