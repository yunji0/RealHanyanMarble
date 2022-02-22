using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialogue4
{
    [TextArea]
    public string dialogue4;
    public Sprite cg4;

}

public class QuizDialogControl_op : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _Sprite4;
    [SerializeField] private Text _Txt4;
    [SerializeField] private Dialogue3[] dialogues4;
    private bool isDialogue = false;

    public int cnt4 = 0;
    [SerializeField] private GameObject ButtonSet1;
    [SerializeField] private GameObject ButtonSet2;

    // Start is called before the first frame update
    void Start()
    {
        ShowDialogue();
    }
    public void ShowDialogue()
    {

        _Sprite4.gameObject.SetActive(true);
        _Txt4.gameObject.SetActive(true);
        cnt4 = 0;
        isDialogue = true;
        NextDialogue();

    }
    private void NextDialogue()
    {
        _Txt4.text = dialogues4[cnt4].dialogue3;
        _Sprite4.sprite = dialogues4[cnt4].cg3;
        ButtonSet1.SetActive(true);
        ButtonSet2.SetActive(false);
        cnt4++;

    }

    void HideDialoge()
    {
        _Sprite4.gameObject.SetActive(false);
        _Txt4.gameObject.SetActive(false);
        cnt4 = 0;
        isDialogue = false;
    }

    public void StartQuiz()
    {
        cnt4 = 1;
        _Txt4.text = dialogues4[cnt4].dialogue3;
        _Sprite4.sprite = dialogues4[cnt4].cg3;
        ButtonSet1.SetActive(false);
        ButtonSet2.SetActive(true);

    }
    public void TrueAn()
    {
        cnt4 = 3;
        _Txt4.text = dialogues4[cnt4].dialogue3;
        _Sprite4.sprite = dialogues4[cnt4].cg3;
    }
    IEnumerator WaitPLZ()
    {
        yield return new WaitForSeconds(4);
        Comeback();
    }
    public void FalseAn()
    {
        ButtonSet1.SetActive(false);
        ButtonSet2.SetActive(false);
        cnt4 = 2;
        _Txt4.text = dialogues4[cnt4].dialogue3;
        _Sprite4.sprite = dialogues4[cnt4].cg3;
        StartCoroutine(WaitPLZ());
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
            if ((GameManagerScript.Hib2b2Place.Find(x => (x == GameManagerScript.NextScene)) != null) || (GameManagerScript.GetHib2b2Place.Find(x => (x == GameManagerScript.NextScene)) == null))
            {
                GameManagerScript.GetHib2b2Place.Add(GameManagerScript.NextScene); //미니게임 종료 후 현재 씬에서 비비를 얻을 수 있나 검사 후 획득, 중복 획득 방지
            }
            if (GameManagerScript.GetHib2b2Place.Count > 2)
            {

                var GM = GameObject.FindGameObjectWithTag("GM");
                Destroy(GM);
                LoadingSceneControl.LoadScene("Menu");  //하이비비 3개가 모이면 게임 종료하여 메뉴로 복귀, 추후에 시간 남으면 종료만을 위한 씬 구성.
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
