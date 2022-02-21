using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManagerScript : MonoBehaviour
{
    public static Vector3 PrePlayerPosition;
  
    private string[] InteractionPlace = {"경상대","언정대","국문대","복지관","학생회관","공학대","과기대","셔틀콕","소융대","약학대","창보","학정","호공","본관","체대","음대","디대","대운동장","기숙사","컨퍼런스홀" }; //cngn
    public static List<string> Hib2b2Place = new List<string>();
    public static List<string> GetHib2b2Place = new List<string>();
   
    public static string CurrentScene = "Menu";
    public static string NextScene;
    public static bool IsBack = false;
    private GameObject player;
    int number1;
    int number2;
    int number3;

    
    private void Awake()
    {
        
        Hib2b2Place.Clear();
        GetHib2b2Place.Clear();
        DontDestroyOnLoad(gameObject);

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

        if (Input.GetKeyDown(KeyCode.O))
        {
            LoadingSceneControl.LoadScene("HanyangMarble");
        }
        try
        {
            player = GameObject.FindGameObjectWithTag("Player");
            CharacterController char1 = player.GetComponent<CharacterController>();

           
            
          
            if (Modecontrol.CurrentGameMode == "Isinteract")
            {
                
                PrePlayerPosition = player.transform.position;
                PrePlayerPosition.y = 0;
              //  print(PrePlayerPosition);
            }
       
                if (IsBack == true)
                {
                //player.transform.position -= PrePlayerPosition;
                // player.transform.Translate(PrePlayerPosition, Space.World);
                //player.transform.position.Set(PrePlayerPosition.position.x, PrePlayerPosition.position.y,PrePlayerPosition.position.z);
                char1.Move(PrePlayerPosition);
              
                    ALL.Idleflag = true;
                    IsBack = false;

                }
      
        }
        catch (System.Exception)
        {

        }
        
    }
}
