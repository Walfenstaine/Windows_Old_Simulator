using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_Controller : MonoBehaviour
{
    public Camera cam;
    public float radius, sensitivity, max_Zoom;
    private float pos_X;
    private float pos_Y;
    private float zoom_Ex;

    private void Start()
    {
        zoom_Ex = cam.orthographicSize;
        max_Zoom = cam.orthographicSize;
    }
    public void Zoom(float zoom) 
    {
        zoom_Ex += zoom * sensitivity;
        zoom_Ex = Mathf.Clamp(zoom_Ex, 0.1f, max_Zoom);
        cam.orthographicSize = zoom_Ex;
    }

    public void Muwe(Vector2 muw)
    {
        pos_Y += muw.y * sensitivity * cam.orthographicSize/200;
        pos_Y = Mathf.Clamp(pos_Y, -radius, radius);
        pos_X += muw.x * sensitivity * cam.orthographicSize / 200;
        pos_X = Mathf.Clamp(pos_X, -radius, radius);
        transform.position = new Vector3(pos_X, pos_Y, 0);
    }
}
