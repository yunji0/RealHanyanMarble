using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    // ��� ���� ��ġ
    public GameObject GetPosition;
    // ��� ������Ʈ
    public GameObject BiBi;
    // ���� cavas
    public GameObject EndCav;


    // Start is called before the first frame update
    void Start()
    {
        EndCav.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // ��� �տ� ������ ��
        if (BiBi.transform.position == GetPosition.transform.position)
        {
            // �浹 ������ ���� Rigidbody ������Ʈ �� �޾ƿ���
            //Rigidbody rb = BiBi.GetComponent<Rigidbody>();
            EndCav.SetActive(true);
        }
    }
}  