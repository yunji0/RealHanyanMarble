using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSceneControl : MonoBehaviour
{
    static string NS;
    public static void LoadScene(string s) {
        NS = s;
        SceneManager.LoadScene("LoadingScene");
    
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadSceneProcess());
    }

    // Update is called once per frame
    void Update()
    {
        
 
    }

    IEnumerator LoadSceneProcess()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(NS);
        op.allowSceneActivation = false;

        while (!op.isDone)
        {
            yield return null;
            if (op.progress < 0.9f)
            {
            }
            else
            {
                yield return new WaitForSeconds(3);
                op.allowSceneActivation = true;
                yield break;
            }
        }
    }
}
