using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame


    private void OnTriggerStay(Collider other)
    {
        if (Modecontrol.CurrentGameMode == "Isinteract")
        {

            if (other.gameObject.tag == "Player")
            { ALL.Idleflag = true; }
        }
    }
}
