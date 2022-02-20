using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class B2B2 : MonoBehaviour
{
    public GameObject cg0;
    public GameObject cg1;
    public GameObject cg2;
    void Start()
    {
        cg0.SetActive(false);
        cg1.SetActive(false);
        cg2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        try
        {


            switch (GameManagerScript.GetHib2b2Place.Count)
            {
                case 3: 
                    cg2.SetActive(true);
                    cg1.SetActive(true);
                    cg0.SetActive(true);
                    break;
                case 2:
                    cg1.SetActive(true);
                    cg0.SetActive(true);
                    break;
                case 1: cg0.SetActive(true);
                    break;
                case 0: break;

                default:
                    break;
            }
        }
        catch (System.Exception)
        {

          
        }
    }
}
