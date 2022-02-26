using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialouge2
{
    [TextArea]
    public string dialogue2;
}

public class EndCavas : MonoBehaviour
{

    [SerializeField] private GameObject EndButton;
    public GameObject EndCav;

    // Start is called before the first frame update
    
    public void Click_End()
    {

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
