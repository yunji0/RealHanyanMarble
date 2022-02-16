using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDialog : MonoBehaviour
{
    public GameObject canvas;
    public DialogControl dialogscript;
    public string nextScene;
    private AudioSource Click;
    public AudioClip ZZan;
    // Start is called before the first frame update
    void Start()
    {
        Click = GetComponent<AudioSource>();
    }
    private void OnTriggerStay(Collider other)
    {
        try
        {
            GameManagerScript.NextScene = nextScene;
        }
        catch (System.Exception)
        {

        }
       
        if (Modecontrol.CurrentGameMode == "Isinteract")
        {
            if (other.gameObject.tag == "Player")
            { canvas.SetActive(true);
                
                if (dialogscript.cnt == 0)
                { dialogscript.ShowDialogue(); }
                
            }
            else { canvas.SetActive(false); }
        }
        else { canvas.SetActive(false); }
    }

    private void OnTriggerEnter(Collider other)
    {
        Click.clip = ZZan;
        Click.Play();
    }
}
