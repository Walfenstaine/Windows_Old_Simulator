using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Input_Controller : MonoBehaviour
{
    public UnityEvent<Vector2> muve;
    public UnityEvent<float> zoom;

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0)) 
        {
            muve.Invoke(new Vector2(-Input.GetAxis("Mouse X"), -Input.GetAxis("Mouse Y")));
        }
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            zoom.Invoke(Input.GetAxis("Mouse ScrollWheel"));
        }
    }
}
