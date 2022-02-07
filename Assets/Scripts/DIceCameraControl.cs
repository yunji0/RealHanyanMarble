using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DIceCameraControl : MonoBehaviour
{
    public GameObject me2;

    // Update is called once per frame
    void Update()
    {
        if (Modecontrol.CurrentGameMode == "Dice")
        {
            me2.SetActive(true);
        }
        else { me2.SetActive(false); }
    }
}
