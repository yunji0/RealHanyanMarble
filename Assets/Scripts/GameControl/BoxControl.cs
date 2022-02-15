using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxControl : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Vector3 vava2=this.transform.position;
            vava2.y = 1.5f;
            other.transform.position = vava2;
        
        }
    }
}
