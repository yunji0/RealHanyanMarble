using System.Collections;
using UnityEngine;

public enum Y_MoleState { UnderGround = 0, OnGround, MoveUp, MoveDown }

public class Y_BBFSM : MonoBehaviour
{
    [SerializeField]
    private float waitTimeOnGround;
    [SerializeField]
    private float limitUnderY;
    [SerializeField]
    private float limitOnY;

    private Y_Movement3D movement3D;

    public Y_MoleState Y_MoleState { private set; get; }

    private void Awake()
    {
        movement3D = GetComponent<Y_Movement3D>();
        ChangeState(Y_MoleState.UnderGround);
    }

    public void ChangeState(Y_MoleState newState)
    {
        StopCoroutine(Y_MoleState.ToString());
        Y_MoleState = newState;
        StartCoroutine(Y_MoleState.ToString());
    }

    private IEnumerator UnderGround()
    {
        movement3D.MoveTo(Vector3.zero);
        transform.position = new Vector3(transform.position.x, limitUnderY, transform.position.z);
        yield return null;
    }

    private IEnumerator OnGround()
    {
        movement3D.MoveTo(Vector3.zero);
        transform.position = new Vector3(transform.position.x, limitOnY, transform.position.z);
        yield return new WaitForSeconds(waitTimeOnGround);
        ChangeState(Y_MoleState.MoveDown);
    }

    private IEnumerator MoveUp()
    {
        movement3D.MoveTo(Vector3.up);

        while (true)
        {
            if (transform.position.y >= limitOnY)
            {
                ChangeState(Y_MoleState.OnGround);
            }
            yield return null;
        }
    }

    private IEnumerator MoveDown()
    {
        movement3D.MoveTo(Vector3.down);

        while (true)
        {
            if (transform.position.y <= limitUnderY)
            {
                ChangeState(Y_MoleState.UnderGround);
            }
            yield return null;
        }
    }
}
