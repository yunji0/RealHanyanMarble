using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFlag : MonoBehaviour
{
    public DiceGameScript ddd;
    public void StartButton()
    {
        ALL.Diceflag = true;
    }

    public void DiceButton1()
    {
     
        ddd.Roll();


       
    }
    public void IntoMoving() {

        ALL.Moveflag = true;
    }
    public void EndMoveButton1()
    {

        ALL.Isinteractflag = true;
    }

    public void IntointeractButton() {

        ALL.Interactflag = true;
    }
    public void EndnteractButton()
    {

        ALL.Idleflag = true;
    }
}
