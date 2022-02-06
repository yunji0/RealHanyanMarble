using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBan : MonoBehaviour
{
    public GameObject me;
    void Awake()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Modecontrol.CurrentGameMode == "Move")
        {
           me.SetActive(true);
            if (ALL.Movenum == 0)
            { ALL.Isinteractflag = true; }
        }
        else  {
            me.SetActive(false);
         
        }

        


     
       
    }
}
