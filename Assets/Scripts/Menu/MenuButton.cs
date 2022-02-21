using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{

    public void HanyangMarbleScene() {

        LoadingSceneControl.LoadScene("RuleExplain");
    }
    public void HanyangUniversityScene()
    {

        LoadingSceneControl.LoadScene("HanyangMarble");
    }

    public void End()
    {
        Application.Quit();
    }
}
