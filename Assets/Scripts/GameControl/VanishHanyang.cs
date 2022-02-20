using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanishHanyang : MonoBehaviour
{
    public GameObject hanyang;
    public GameObject player;
    private AudioSource AS;
 
    void Start()
    {
        AS = GetComponent<AudioSource>();
  

    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(Vector3.Distance(hanyang.transform.position, player.transform.position)) < 5)
        {
            hanyang.SetActive(false);
            if (Modecontrol.CurrentGameMode == "Isinteract")
            { AS.mute = false; }
            else
            { AS.mute = true; }
        }
        else { hanyang.SetActive(true);
            AS.mute = true;
        }

    }


}
