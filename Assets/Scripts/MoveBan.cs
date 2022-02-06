using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBan : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject me;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Modecontrol.CurrentGameMode == "Move")
        {
            me.SetActive(false);
        }
        else
        {
            me.SetActive(true);

        }
    }
}
