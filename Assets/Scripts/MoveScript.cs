using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveScript : MonoBehaviour
{
    public Text _text;
    

    // Update is called once per frame
    void Update()
    {
        _text.text = $"{ALL.Movenum}Ä­ ÀÌµ¿ °¡´É!!";
    }
}
