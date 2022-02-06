using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceScript : MonoBehaviour
{
    public Rigidbody RB;
    public Transform[] Nums;
    public int num=0;

    public IEnumerator Roll()
    {
        yield return null;
        transform.position = new Vector3(-60f, -20f, -20f);  //주사위 던지기 위해 올리기
        transform.localEulerAngles = new Vector3(Random.Range(-90f, 90f), Random.Range(-90f, 90f), Random.Range(-90f, 90f));    //초기 랜덤 값
        RB.angularVelocity = Random.insideUnitSphere * Random.Range(-1000, 1000);   //랜덤 회전 속력

        yield return new WaitForSeconds(3); //주사위 값을 안전하게 찾기 위해 3초 대기

        
        
        while (true)
        {
            yield return null;
            if (RB.velocity.sqrMagnitude < 0.001f)  //계산량 적게 하기 위해 제곱근사용
                break;
        }

        for (int i = 0; i < Nums.Length; i++)
        {
            if (Nums[i].position.y > 1)  //윗면의 y값으로 판단
            {
                num = i + 1;    //인덱스 + 1 = 주사위 눈금
                ALL.Movenum = num;
                print(num);
                break;
            }
            else { ALL.Movenum = 3; } //임시 지정값 3
        }
      
    }
}
