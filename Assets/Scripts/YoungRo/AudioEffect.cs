using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEffect : MonoBehaviour
{
    private AudioSource Click;
    public AudioClip Shuck;

    // Start is called before the first frame update
    void Start()
    {
        Click = GetComponent<AudioSource>();    
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "SoundEffect")
        {
            Click.clip = Shuck;
            Click.Play();
        }
    }
}
