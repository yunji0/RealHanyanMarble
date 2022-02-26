using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class DialougeY
{
    [TextArea]
    public string dialogue;
}

public class StartCavas : MonoBehaviour
{

    //[SerializeField] private SpriteRenderer sprite_StandginCG;
    [SerializeField] private SpriteRenderer sprite_DialogueBox;
    [SerializeField] private Text text_Dialogue;
    [SerializeField] private DialougeY[] dialogue;

    private bool isDialogue = false;
    private int count = 0;


    [SerializeField] private GameObject StartButton;
    [SerializeField] private GameObject NextButton;

    public GameObject StartCav;
    public GameObject DistanceR;
    public GameObject DistanceL;

    private void Awake()
    {
        DistanceL.SetActive(false);
        DistanceR.SetActive(false);
    }

    private void Start()
    {
        ShowDialouge();
    }

    public void ShowDialouge()
    {
        sprite_DialogueBox.gameObject.SetActive(true);
        //sprite_StandginCG.gameObject.SetActive(true);
        text_Dialogue.gameObject.SetActive(true);
        NextButton.SetActive(true);
        StartButton.SetActive(false);
        count = 0;
        isDialogue = true;
        NextDialogue();
    }

 //    private void NextDialouge()
 //   {
 //       text_Dialogue.text = dialouge[count].dialogue;
 //       sprite_StandginCG.sprite = dialouge[count].cg;
 //       count++;
 //   }

    public void NextDialogue()
    {
        switch (count)
        {
            case 0:
                text_Dialogue.text = dialogue[count].dialogue;
                count++;
                break;
            case 1:
                text_Dialogue.text = dialogue[count].dialogue;
                count++;
                break;
            case 2:
                text_Dialogue.text = dialogue[count].dialogue;
                count++;
                break;
            default:
                text_Dialogue.text = dialogue[count].dialogue;
                count++;
                NextButton.SetActive(false);
                StartButton.SetActive(true);
                break;
        }
    }

    public void Click()
    {
        StartCav.SetActive(false);
        DistanceL.SetActive(true);
        DistanceR.SetActive(true);
    }




}
