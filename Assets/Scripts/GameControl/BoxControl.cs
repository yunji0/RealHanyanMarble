using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxControl : MonoBehaviour
{
    //LocomotionController loco;
    // Start is called before the first frame update
    Vector3 a;
    private AudioSource Click;
    public AudioClip Shuck;
    void Start()
    {
        Click = GetComponent<AudioSource>();
    }
    private void Update()
    {
        try
        {
          // loco = GameObject.Find("TeleportControl").GetComponent<LocomotionController>();
          //  print(loco.CharacterController.transform.position);
        }
        catch (System.Exception)
        {

           
        }
      
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")

        {
            a = this.transform.position - other.transform.position;
            a.y = 0f;
            other.GetComponent<CharacterController>().Move(a);
            Click.clip = Shuck;
            Click.Play();

        }
    }
}
