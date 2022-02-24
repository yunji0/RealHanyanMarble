using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiBiCollision : MonoBehaviour
{

    public GameObject EndCav;
    public GameObject BiBi;
    public GameObject DistanceR;
    public GameObject DistanceL;

    // Start is called before the first frame update
    void Start()
    {
        EndCav.SetActive(false);
        BiBi.SetActive(true);
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "GetPostion" && OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
        {
            EndCav.SetActive(true);
            BiBi.SetActive(false);
            DistanceL.SetActive(false);
            DistanceR.SetActive(false);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
