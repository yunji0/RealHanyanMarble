using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class RDialogue
{
    [TextArea]
    public string dialogue;
}

public class RuleDialogue : MonoBehaviour
{
    [SerializeField]
    private Text text_Dialogue;

    [SerializeField]
    private Button button;

    private int countDialogue = 0;

    [SerializeField]
    private RDialogue[] dialogue;

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
        if (countDialogue == dialogue.Length)
        {
            button.gameObject.SetActive(false);

            /*
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
            */
        }
    }
}
