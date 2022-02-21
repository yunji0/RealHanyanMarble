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
            */
        }
    }
}
