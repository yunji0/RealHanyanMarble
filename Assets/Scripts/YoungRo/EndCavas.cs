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
            GameManagerScript.IsBack = true;
            LoadingSceneControl.LoadScene("HanyangMarble");
        }
        catch (System.Exception)
        {

        }
    }

}
