using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasControl : MonoBehaviour
{
    GameObject ChildGameObject1;
    GameObject ChildGameObject2;
    GameObject ChildGameObject3;
    GameObject ChildGameObject4;
    GameObject ChildGameObject5;
    GameObject ChildGameObject0;
    [SerializeField]
    private GameObject Canvas;
    // Start is called before the first frame update
   void Awake()
    {
            ChildGameObject0 = Canvas.transform.GetChild(0).gameObject;
            ChildGameObject1 = Canvas.transform.GetChild(1).gameObject;
            ChildGameObject2 = Canvas.transform.GetChild(2).gameObject;
            ChildGameObject3 = Canvas.transform.GetChild(3).gameObject;
            ChildGameObject4 = Canvas.transform.GetChild(4).gameObject;
            ChildGameObject5 = Canvas.transform.GetChild(5).gameObject;
           
        
    }
   
    private void Start()
    {

    }
  void Update()
    {
        if (Modecontrol.CurrentGameMode == "Start")
        {
            ChildGameObject0.SetActive(true);
            ChildGameObject1.SetActive(false);
            ChildGameObject2.SetActive(false);
            ChildGameObject3.SetActive(false);
            ChildGameObject4.SetActive(false);
            ChildGameObject5.SetActive(false);
        }
        else if (Modecontrol.CurrentGameMode == "Dice")
        {
            ChildGameObject0.SetActive(false);
            ChildGameObject1.SetActive(true);
            ChildGameObject2.SetActive(false);
            ChildGameObject3.SetActive(false);
            ChildGameObject4.SetActive(false);
            ChildGameObject5.SetActive(false);
        }
        else if (Modecontrol.CurrentGameMode == "Move")
        {
            ChildGameObject0.SetActive(false);
            ChildGameObject1.SetActive(false);
            ChildGameObject2.SetActive(true);
            ChildGameObject3.SetActive(false);
            ChildGameObject4.SetActive(false);
            ChildGameObject5.SetActive(false);
        }
        else if (Modecontrol.CurrentGameMode == "Isinteract")
        {
            ChildGameObject0.SetActive(false);
            ChildGameObject1.SetActive(false);
            ChildGameObject2.SetActive(false);
          //  ChildGameObject3.SetActive(true);
            ChildGameObject4.SetActive(false);
            ChildGameObject5.SetActive(false);
        }
        else if (Modecontrol.CurrentGameMode == "Interact")
        {
            ChildGameObject0.SetActive(false);
            ChildGameObject1.SetActive(false);
            ChildGameObject2.SetActive(false);
            ChildGameObject3.SetActive(false);
            ChildGameObject4.SetActive(true);
            ChildGameObject5.SetActive(false);
        }
        else if (Modecontrol.CurrentGameMode == "Idle")
        {
            ChildGameObject0.SetActive(false);
            ChildGameObject1.SetActive(false);
            ChildGameObject2.SetActive(false);
            ChildGameObject3.SetActive(false);
            ChildGameObject4.SetActive(false);
            ChildGameObject5.SetActive(true);
        }
    }
}
