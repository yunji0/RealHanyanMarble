using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




[System.Serializable]
public class Dialogue2
{
    [TextArea]
    public string dialogue2;
    public Sprite cg2;

}
public class DialogContorlInNewS : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _Sprite2;
    [SerializeField] private Text _Txt2;
    [SerializeField] private Dialogue[] dialogues2;
    private bool isDialogue = false;

    public int cnt2 = 0;



    //showDialogue trigger

    private void Start()
    {
        ShowDialogue();
    }
    public void ShowDialogue()
    {

        _Sprite2.gameObject.SetActive(true);
        _Txt2.gameObject.SetActive(true);
        cnt2 = 0;
        isDialogue = true;
        NextDialogue();

    }

    private void NextDialogue()
    {
        _Txt2.text = dialogues2[cnt2].dialogue;
        _Sprite2.sprite = dialogues2[cnt2].cg;
        cnt2++;

    }

    void HideDialoge()
    {
        _Sprite2.gameObject.SetActive(false);
        _Txt2.gameObject.SetActive(false);
        cnt2 = 0;
        isDialogue = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (isDialogue)
        {
            if (OVRInput.GetDown(OVRInput.Button.Two) || Input.GetKeyDown(KeyCode.H))
            {
                if (cnt2 < dialogues2.Length)
                { NextDialogue(); }
                else
                {
                    HideDialoge();
                    ALL.Interactflag = true;// ÈÄ¿¡ ¿ÀÇÂ ¾À
                }
            }

        }

    }
}

