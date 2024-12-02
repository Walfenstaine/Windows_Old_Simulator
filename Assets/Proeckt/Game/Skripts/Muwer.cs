using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Muwer : MonoBehaviour
{
    public AudioClip kik, bang, ded, clik;
    public Image power;
    public Image image;
    public Rigidbody2D rb;
    public Transform looker;
    public static Muwer regit;
    private Vector3 pos;
    public static Muwer rid { get; set; }
    void Awake()
    {
        if (rid == null)
        {
            rid = this;
        }
        else
        {
            Destroy(this);
        }
    }
    void OnDestroy()
    {
        rid = null;
    }

    public void Rebort() 
    {
        transform.localPosition = pos;
        rb.velocity = Vector3.zero;
        SoundPlayer.regit.Play(ded);
    }
    public void Kik() 
    {
        if (image.enabled) 
        {
            rb.AddForce(looker.forward * power.fillAmount*50000);
            SoundPlayer.regit.Play(kik);
        }
    }
    private void FixedUpdate()
    {
        Vector2 pos = Input.mousePosition;
        looker.LookAt(pos);
        if (rb.velocity.magnitude > 12.0f)
        {
            image.enabled = false;
        }
        else 
        {
            pos = transform.localPosition;
            image.enabled = true;
        }
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
