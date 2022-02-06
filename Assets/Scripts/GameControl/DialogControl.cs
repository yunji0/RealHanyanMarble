using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class Dialogue {
    [TextArea]
    public string dialogue;
    public Sprite cg;

}
public class DialogControl : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _Sprite;
    [SerializeField] private Text _Txt;
    [SerializeField] private Dialogue[] dialogues;
    private bool isDialogue = false;

    public int cnt = 0;
    public void ShowDialogue() {

        _Sprite.gameObject.SetActive(true);
        _Txt.gameObject.SetActive(true);
        cnt = 0;
        isDialogue = true;
        NextDialogue();
    
    }

    private void NextDialogue()
    {
        _Txt.text = dialogues[cnt].dialogue;
        _Sprite.sprite = dialogues[cnt].cg;
        cnt++;
    
    }

    void HideDialoge() {
        _Sprite.gameObject.SetActive(false);
        _Txt.gameObject.SetActive(false);
        cnt = 0;
        isDialogue = false;

    }

    // Update is called once per frame
    void Update()
    {
       
        if (isDialogue)
        {
            if (OVRInput.GetDown(OVRInput.Button.Two)||Input.GetKeyDown(KeyCode.H))
            {
                if (cnt < dialogues.Length)
                { NextDialogue(); }
                else { HideDialoge(); 
                    ALL.Interactflag = true;// ÈÄ¿¡ ¿ÀÇÂ ¾À
                }
            }
        
        }
        
    }
}
