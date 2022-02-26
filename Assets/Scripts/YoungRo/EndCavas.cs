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
                GameManagerScript.GetHib2b2Place.Add(GameManagerScript.NextScene); //�̴ϰ��� ���� �� ���� ������ ��� ���� �� �ֳ� �˻� �� ȹ��, �ߺ� ȹ�� ����
            }
            if (GameManagerScript.GetHib2b2Place.Count > 2)
            {

                var GM = GameObject.FindGameObjectWithTag("GM");
                Destroy(GM);
                LoadingSceneControl.LoadScene("EndingScene");  //���̺�� 3���� ���̸� ���� �����Ͽ� �޴��� ����, ���Ŀ� �ð� ������ ���Ḹ�� ���� �� ����.
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
