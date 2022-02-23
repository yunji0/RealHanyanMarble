using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class EDialogue
{
    [TextArea]
    public string dialogue;
}

public class EndingDialogue : MonoBehaviour
{
    [SerializeField]
    private Text text_Dialogue;

    [SerializeField]
    private Button buttonContinue;

    [SerializeField]
    private Button buttonExit;

    private int countDialogue = 0;

    [SerializeField]
    private EDialogue[] dialogue;

    public void NextDialogue()
    {
        if (countDialogue < dialogue.Length)
        {
            text_Dialogue.text = dialogue[countDialogue].dialogue;
            countDialogue++;
        }
        else
        {
            buttonExit.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if(countDialogue == 4)
        {
            buttonContinue.gameObject.SetActive(false);
            buttonExit.gameObject.SetActive(true);
        }

        if (countDialogue == dialogue.Length)
        {
            buttonExit.gameObject.SetActive(false);
            LoadingSceneControl.LoadScene("Menu");
        }
    }
}
