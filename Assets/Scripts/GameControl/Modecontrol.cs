using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modecontrol : MonoBehaviour
{
    private string[] GameMode = { "Start", "Dice", "Move", "Isinteract", "Interact", "Idle" };
    [SerializeField]
    public static string CurrentGameMode;
    int ik = 0;
    private void Awake()
    {
        CurrentGameMode = GameMode[0];
    
    }


    // Update is called once per frame
    void Update()
    {

        if (ALL.Diceflag == true)
        {
            CurrentGameMode = GameMode[1];

            ALL.Diceflag = false;
        }
        else if (ALL.Moveflag == true)
        {
            CurrentGameMode = GameMode[2];

            ALL.Moveflag = false;
        }
        else if (ALL.Isinteractflag == true)
        {
            CurrentGameMode = GameMode[3];

            ALL.Isinteractflag = false;
        }
        else if (ALL.Interactflag == true)
        {
            CurrentGameMode = GameMode[4];

            ALL.Interactflag = false;
        }
        else if (ALL.Idleflag == true)
        {
            CurrentGameMode = GameMode[5];

            ALL.Idleflag = false;
        }


        if (OVRInput.GetDown(OVRInput.Button.One) ||Input.GetKeyDown(KeyCode.Z))
        {
            if (Modecontrol.CurrentGameMode == "Move")
            { ALL.Movenum = 0; }
        }
       // if (Input.GetKeyDown(KeyCode.P)|| OVRInput.GetDown(OVRInput.Button.Two)) { this.GetComponent<CharacterController>().Move(new Vector3(0.0f, 1.5f, 20.0f)); }

            if (Input.GetKeyDown(KeyCode.D))
            { CurrentGameMode = GameMode[ik];
            ik++;
            if (ik == 6) { ik = 1; }
                }
      
    }
}
