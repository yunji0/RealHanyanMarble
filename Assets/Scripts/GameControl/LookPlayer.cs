using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookPlayer : MonoBehaviour
{
    public Transform target;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(target);
    }
}
