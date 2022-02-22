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
                GameManagerScript.GetHib2b2Place.Add(GameManagerScript.NextScene); //�̴ϰ��� ���� �� ���� ������ ��� ���� �� �ֳ� �˻� �� ȹ��, �ߺ� ȹ�� ����
            }
            if (GameManagerScript.GetHib2b2Place.Count > 2)
            {

                var GM = GameObject.FindGameObjectWithTag("GM");
                Destroy(GM);
                LoadingSceneControl.LoadScene("Menu");  //���̺�� 3���� ���̸� ���� �����Ͽ� �޴��� ����, ���Ŀ� �ð� ������ ���Ḹ�� ���� �� ����.
            }
            else
            {
                GameManagerScript.IsBack = true;
                LoadingSceneControl.LoadScene("HanyangMarble");
            } //���̺�� ���� 3�� �̸��̸� �ٽ� �������� ����

        }
        catch (System.Exception)
        {

        }

    }
}
