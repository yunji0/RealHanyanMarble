using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick1()
    {
        Debug.Log("1��");
    }

    public void OnClick2()
    {
        Debug.Log("2��");
    }
    
    public void OnClick3()
    {
        Debug.Log("3��");
    }

    public void OnClickQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; 
#else
        Application.Quit();

#endif
    }
}
