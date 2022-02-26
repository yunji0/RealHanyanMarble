using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueY
{
    [TextArea]
    public string dialogue;
}

public class StartCavas : MonoBehaviour
{

    [SerializeField] private Text _text;
    [SerializeField] private DialogueY[] dialogueY;
    
    private int count = 0;
    /*
     * 
     *여기에 참조할 버튼 알아서 넣기 
     */

    private void Start()
    {
        ShowDialogue();
    }

    private void ShowDialogue() {

        _text.text = dialogueY[count].dialogue;
        count++;
    }

    public void NextDialogue() {

        _text.text = dialogueY[count].dialogue;
        count++;
       

       
    }
}

   