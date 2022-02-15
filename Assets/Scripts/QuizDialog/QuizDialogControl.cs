using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




[System.Serializable]
public class Dialogue3
{
    [TextArea]
    public string dialogue3;
    public Sprite cg3;

}
public class QuizDialogControl : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _Sprite3;
    [SerializeField] private Text _Txt3;
    [SerializeField] private Dialogue3[] dialogues3;
    private bool isDialogue = false;

    public int cnt3 = 0;
    [SerializeField] private GameObject ButtonSet1;
    [SerializeField] private GameObject ButtonSet2;


    //showDialogue trigger

    private void Start()
    {
        ShowDialogue();
    }
    public void ShowDialogue()
    {

        _Sprite3.gameObject.SetActive(true);
        _Txt3.gameObject.SetActive(true);
        cnt3 = 0;
        isDialogue = true;
        NextDialogue();

    }

    private void NextDialogue()
    {
        _Txt3.text = dialogues3[cnt3].dialogue3;
        _Sprite3.sprite = dialogues3[cnt3].cg3;
        ButtonSet1.SetActive(true);
        ButtonSet2.SetActive(false);
        cnt3++;

    }

    void HideDialoge()
    {
        _Sprite3.gameObject.SetActive(false);
        _Txt3.gameObject.SetActive(false);
        cnt3 = 0;
        isDialogue = false;
    }

    public void StartQuiz()
    {
        cnt3 = 1;
        _Txt3.text = dialogues3[cnt3].dialogue3;
        _Sprite3.sprite = dialogues3[cnt3].cg3;
        ButtonSet1.SetActive(false);
        ButtonSet2.SetActive(true);

    }
    public void TrueAn()
    {
        ButtonSet1.SetActive(false);
        ButtonSet2.SetActive(false);
        cnt3 = 2;
        _Txt3.text = dialogues3[cnt3].dialogue3;
        _Sprite3.sprite = dialogues3[cnt3].cg3;
        StartCoroutine(WaitPLZ());

    }
    IEnumerator WaitPLZ() {
        yield return new WaitForSeconds(5);
        Comeback();
    }

    public void FalseAn()
    {
        cnt3 = 3;
        _Txt3.text = dialogues3[cnt3].dialogue3;
        _Sprite3.sprite = dialogues3[cnt3].cg3;

    }
    public void Comeback()
    {
        HideDialoge();
        try
        {
            GameManagerScript.IsBack = true;
            LoadingSceneControl.LoadScene("HanyangMarble");
        }
        catch (System.Exception)
        {

        }

    }

}
   

