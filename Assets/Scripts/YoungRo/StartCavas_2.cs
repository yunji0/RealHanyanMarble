using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialouge_st
{
    [TextArea] public string dialogue;
}

public class StartCavas_2 : MonoBehaviour
{

    [SerializeField] private Text text_Dialogue;
    [SerializeField] private Button button;

    private bool isDialogue = false;
    private int count = 0;

    [SerializeField] private Dialouge_st[] dialogue;


    [SerializeField] private GameObject StartButton;

    public GameObject StartCav;
    public GameObject DistanceR;
    public GameObject DistanceL;

    public void ShowDialouge()
    {
        text_Dialogue.gameObject.SetActive(true);

        count = 0;
        isDialogue = true;
    }

    public void NextDialouge()
    {
        if (count < dialogue.Length)
        {
            text_Dialogue.text = dialogue[count].dialogue;
            count++;
        }
        else
        {
            StartCav.SetActive(false);
            DistanceL.SetActive(true);
            DistanceR.SetActive(true);
        }
    }

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
    // Start is called before the first frame update
    void Start()
    {
        ShowDialouge();
    }


}
