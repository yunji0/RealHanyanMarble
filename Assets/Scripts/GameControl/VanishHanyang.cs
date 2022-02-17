using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanishHanyang : MonoBehaviour
{
    public GameObject hanyang;
    public GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(Vector3.Distance(hanyang.transform.position, player.transform.position)) < 5)
        {
            hanyang.SetActive(false);
        }
        else { hanyang.SetActive(true); }
    }
}
