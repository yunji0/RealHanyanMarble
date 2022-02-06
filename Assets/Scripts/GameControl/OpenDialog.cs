using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDialog : MonoBehaviour
{
    public GameObject canvas;
    public DialogControl dialogscript;
    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    {
      
        if (Modecontrol.CurrentGameMode == "Isinteract")
        {
            if (other.gameObject.tag == "Player")
            { canvas.SetActive(true);

                if (dialogscript.cnt == 0)
                { dialogscript.ShowDialogue(); }
                
            }
            else { canvas.SetActive(false); }
        }
        else { canvas.SetActive(false); }
    }

    
}
