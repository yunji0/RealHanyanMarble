using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioWithIndex : MonoBehaviour
{
    private AudioSource Click;
    void Start()
    {
        Click = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger)||Input.GetKeyDown(KeyCode.Z))
        {
            print("Click");
            Click.Play();
        }
    }
}
