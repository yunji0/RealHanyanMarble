using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceGameScript : MonoBehaviour
{
    public DiceScript diceScript;


    //public Transform[] Pos;

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Roll();
        }
    }

    public void Roll()
    {
        StartCoroutine(RollCo());
    }

    IEnumerator RollCo()
    {
        yield return StartCoroutine(diceScript.Roll());
    
        yield return new WaitForSeconds(0.5f);
        Modecontrol.CurrentGameMode = "Move";
    }
}