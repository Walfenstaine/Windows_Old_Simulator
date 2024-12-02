using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BildEditor : MonoBehaviour
{
    public Vector3 coordinat;
    public Reeeeeeeed reeder;
    public GameObject bild;
    private void Start()
    {
        for (int i = 0; i < reeder.pos.Count; i++) 
       {
            GameObject gidpant = Instantiate(bild);
            gidpant.transform.localPosition = (reeder.pos[i] - coordinat);
            gidpant.transform.SetParent(this.transform);
            gidpant.transform.localScale = new Vector3(1,1,1);
        }
    }
}
