using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialouge
{
    [TextArea]
    public string dialogue;
}

public class StartCavas : MonoBehaviour
{

    [SerializeField] private SpriteRenderer sprite_StandginCG;
    [SerializeField] private SpriteRenderer sprite_DialogueBox;
    [SerializeField] private Text text_Dialogue;

    private bool isDialogue = false;
    private int count = 0;

    [SerializeField] private Dialogue[] dialouge;

    [SerializeField] private GameObject StartButton;

    public GameObject StartCav;
    public GameObject DistanceR;
    public GameObject DistanceL;


    public void ShowDialouge()
    {
        sprite_DialogueBox.gameObject.SetActive(true);
        sprite_StandginCG.gameObject.SetActive(true);
        text_Dialogue.gameObject.SetActive(true);

        count = 0;
        isDialogue = true;
    }

 //    private void NextDialouge()
 //   {
 //       text_Dialogue.text = dialouge[count].dialogue;
 //       sprite_StandginCG.sprite = dialouge[count].cg;
 //       count++;
 //   }

    public void Click()
    {
        StartCav.SetActive(false);
        DistanceL.SetActive(true);
        DistanceR.SetActive(true);
    }

    private void Awake()
    {
        DistanceL.SetActive(false);
        DistanceR.SetActive(false);
    }

    private void Start()
    {
        ShowDialouge();
    }
}
