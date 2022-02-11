using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ALL : MonoBehaviour
{
    public static bool Diceflag;
    public static bool Moveflag;
    public static bool Isinteractflag;
    public static bool Interactflag;
    public static bool Idleflag;
    public static int Movenum;

    private void Awake()
    {
        Diceflag = false;
        Moveflag = false;
        Isinteractflag = false;
        Interactflag = false;
        Idleflag = false;
        Movenum = 0;
       
    }

}
