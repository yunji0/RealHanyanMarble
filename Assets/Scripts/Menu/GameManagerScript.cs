using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManagerScript : MonoBehaviour
{
    public static Transform PrePlayerPosition;
  
    private string[] InteractionPlace = {"1", "2", "3", "4" }; //cngn
    public static List<string> Hib2b2Place = new List<string>();
    public static string CurrentScene = "Menu";
    public static string NextScene;
    public static bool IsBack = false;
    private GameObject player;
    int number1;
    int number2;
    int number3;

    private void Awake()
    {
       

    }

    List<string> GetRandom() 
    {
        for (; ; )
        {
           number1 = Random.Range(0, InteractionPlace.Length);
           number2 = Random.Range(0, InteractionPlace.Length);
           number3 = Random.Range(0, InteractionPlace.Length);

            if ((number1 == number2) || (number1 == number3) || (number3 == number2))
            {
                continue;
            }
            else { break; }
        }
        Hib2b2Place.Add(InteractionPlace[number1]);
        Hib2b2Place.Add(InteractionPlace[number2]);
        Hib2b2Place.Add(InteractionPlace[number3]);

        return Hib2b2Place;
    }
    void Start()
    {

        GetRandom();

        //print(Hib2b2Place[0]);
        //print(Hib2b2Place[1]);
        //print(Hib2b2Place[2]);


    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            player = GameObject.FindGameObjectWithTag("player");

            if (Modecontrol.CurrentGameMode == "Isinteract")
            {
                PrePlayerPosition.position = player.transform.position;
            }
            else if (Modecontrol.CurrentGameMode == "Idle")
            {
                player.transform.position = PrePlayerPosition.position;
            }

            if (IsBack == true) {
                ALL.Idleflag = true;
                IsBack = false;
            }
        }
        catch (System.Exception)
        {

        }
      
    }
}
