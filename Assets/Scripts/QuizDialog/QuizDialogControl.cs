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

    private int cnt3 = 0;
    [SerializeField] private GameObject ButtonStart;
    [SerializeField] private GameObject ButtonOX;
    [SerializeField] private GameObject ButtonNext;

    [SerializeField] private AudioSource SoundCorrect;
    [SerializeField] private AudioSource SoundWrong;

    //showDialogue trigger

    private void Start()
    {
        ShowDialogue();
    }

    public void ShowDialogue()
    {
        _Sprite3.gameObject.SetActive(true);
        _Txt3.gameObject.SetActive(true);
        ButtonStart.SetActive(false);
        ButtonNext.SetActive(true);
        cnt3 = 0;
        isDialogue = true;
        NextDialogue();
    }

    public void NextDialogue()
    {
        _Txt3.text = dialogues3[cnt3].dialogue3;
        _Sprite3.sprite = dialogues3[cnt3].cg3;
        if (cnt3 == 3)
        {
            ButtonStart.SetActive(true);
            ButtonNext.SetActive(false);
        }
        ButtonOX.SetActive(false);
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
        cnt3 = 4;
        _Txt3.text = dialogues3[cnt3].dialogue3;
        _Sprite3.sprite = dialogues3[cnt3].cg3;
        ButtonStart.SetActive(false);
        ButtonOX.SetActive(true);
    }

    public void TrueAn()
    {
        ButtonStart.SetActive(false);
        ButtonOX.SetActive(false);
        cnt3 = 5;
        _Txt3.text = dialogues3[cnt3].dialogue3;
        _Sprite3.sprite = dialogues3[cnt3].cg3;
        SoundCorrect.Play();
        StartCoroutine(WaitPLZ());
    }

    IEnumerator WaitPLZ() {
        yield return new WaitForSeconds(4);
        Comeback();
    }

    public void FalseAn()
    {
        cnt3 = 6;
        _Txt3.text = dialogues3[cnt3].dialogue3;
        _Sprite3.sprite = dialogues3[cnt3].cg3;
        SoundWrong.Play();
        StartCoroutine(ReQuiz());
    }

    IEnumerator ReQuiz()
    {
        yield return new WaitForSeconds(2);
        StartQuiz();
    }

    public void Comeback()
    {
        HideDialoge();
        /*
        try
        {
            GameManagerScript.IsBack = true;
            LoadingSceneControl.LoadScene("HanyangMarble");
        }
        catch (System.Exception)
        {

        }*/

        try
        {
            if (!(GameManagerScript.Hib2b2Place.Find(x => (x == GameManagerScript.NextScene)) == null) && (GameManagerScript.GetHib2b2Place.Find(x => (x == GameManagerScript.NextScene)) == null))
            {
                GameManagerScript.GetHib2b2Place.Add(GameManagerScript.NextScene); //미니게임 종료 후 현재 씬에서 비비를 얻을 수 있나 검사 후 획득, 중복 획득 방지
            }
            if (GameManagerScript.GetHib2b2Place.Count > 2)
            {

                var GM = GameObject.FindGameObjectWithTag("GM");
                Destroy(GM);
                LoadingSceneControl.LoadScene("EndingScene");  //하이비비 3개가 모이면 게임 종료하여 메뉴로 복귀, 추후에 시간 남으면 종료만을 위한 씬 구성.
            }
            else
            {
                GameManagerScript.IsBack = true;
                LoadingSceneControl.LoadScene("HanyangMarble"); 
            } //하이비비가 아직 3개 미만이면 다시 게임으로 복귀

        }
        catch (System.Exception)
        {

        }
    }
}