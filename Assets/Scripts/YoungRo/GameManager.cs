using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    // 비비를 받을 위치
    public GameObject GetPosition;
    // 비비 오브젝트
    public GameObject BiBi;
    // 종료 cavas
    public GameObject EndCav;


    // Start is called before the first frame update
    void Start()
    {
        EndCav.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // 비비가 손에 들어왔을 때
        if (BiBi.transform.position == GetPosition.transform.position)
        {
            // 충돌 감지를 위해 Rigidbody 컴포넌트 값 받아오기
            //Rigidbody rb = BiBi.GetComponent<Rigidbody>();
            EndCav.SetActive(true);
        }
    }
}  