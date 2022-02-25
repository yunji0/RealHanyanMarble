using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hib2b2isHere : MonoBehaviour
{
    private Text _text;
    string str1;
    void Start()
    {
        _text = GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            str1 = $"{GameManagerScript.Hib2b2Place[0]}, {GameManagerScript.Hib2b2Place[1]}, {GameManagerScript.Hib2b2Place[2]}¿¡ ¼û¾îÀÖÁö·Õ!";
            _text.text = str1;
        }
        catch (System.Exception)
        {
            print("text¿À·ù");
        
        }
    }
}
