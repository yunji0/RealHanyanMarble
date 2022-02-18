using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class MDialogue
{
    [TextArea]
    public string dialogue;
}

public class MoleDialogue : MonoBehaviour
{
    [SerializeField]
    private BBSpawner spawner;

    [SerializeField]
    private Text text_Dialogue;

    [SerializeField]
    private Button button;

    private int countDialogue = 0;

    [SerializeField]
    private MDialogue[] dialogue;

    public void NextDialogue()
    {
        if (countDialogue < dialogue.Length)
        {
            text_Dialogue.text = dialogue[countDialogue].dialogue;
            countDialogue++;
        }
        else
        {
            button.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (countDialogue == 4)
        {
            button.gameObject.SetActive(false);

            if (spawner.isGame == false)
            {
                text_Dialogue.text = dialogue[countDialogue].dialogue;
                countDialogue++;
                button.gameObject.SetActive(true);
            }
        }

        else if (countDialogue == dialogue.Length)
        {
            button.gameObject.SetActive(false);
        }
    }
}
