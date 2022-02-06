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
        transform.position = new Vector3(-60f, -20f, -20f);  //�ֻ��� ������ ���� �ø���
        transform.localEulerAngles = new Vector3(Random.Range(-90f, 90f), Random.Range(-90f, 90f), Random.Range(-90f, 90f));    //�ʱ� ���� ��
        RB.angularVelocity = Random.insideUnitSphere * Random.Range(-1000, 1000);   //���� ȸ�� �ӷ�

        yield return new WaitForSeconds(3); //�ֻ��� ���� �����ϰ� ã�� ���� 3�� ���

        
        
        while (true)
        {
            yield return null;
            if (RB.velocity.sqrMagnitude < 0.001f)  //��귮 ���� �ϱ� ���� �����ٻ��
                break;
        }

        for (int i = 0; i < Nums.Length; i++)
        {
            if (Nums[i].position.y > 1)  //������ y������ �Ǵ�
            {
                num = i + 1;    //�ε��� + 1 = �ֻ��� ����
                ALL.Movenum = num;
                print(num);
                break;
            }
            else { ALL.Movenum = 3; } //�ӽ� ������ 3
        }
      
    }
}
