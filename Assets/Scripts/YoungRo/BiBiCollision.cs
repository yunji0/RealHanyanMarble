using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiBiCollision : MonoBehaviour
{

    public GameObject EndCav;

    // Start is called before the first frame update
    void Start()
    {
        EndCav.SetActive(false);
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "GetPostion")
        {
            EndCav.SetActive(true);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
