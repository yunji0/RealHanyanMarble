using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform Camera1;
    public Transform Camera2;


    // Update is called once per frame
    void Update()
    {
        if (Modecontrol.CurrentGameMode == "Move" || Modecontrol.CurrentGameMode == "Isinteract" || Modecontrol.CurrentGameMode == "Interact")
        {
            this.transform.position = Camera1.position;
        }
        else { this.transform.position = Camera2.position; }
    }
}
