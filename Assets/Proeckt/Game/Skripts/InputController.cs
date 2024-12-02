using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class InputController : MonoBehaviour
{
    private float timer;
    void Update()
    {
        if (YandexGame.EnvironmentData.isDesktop) 
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Muwer.rid.Kik();
            }
        }
        if (YandexGame.EnvironmentData.isMobile)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                timer = Time.time + 0.5f;
            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                if (timer > Time.time) 
                {
                    Muwer.rid.Kik();
                }
            }
        }
    }
}
