using System.Collections;
using UnityEngine;

public enum MoleState { UnderGround = 0, OnGround, MoveUp, MoveDown }

public class BBFSM : MonoBehaviour
{
    [SerializeField]
    private float waitTimeOnGround;
    [SerializeField]
    private float limitUnderZ;
    [SerializeField]
    private float limitOnZ;

    private Movement3D movement3D;

    public MoleState Molestate { private set; get; }

    private void Awake()
    {
        movement3D = GetComponent<Movement3D>();
        ChangeState(MoleState.UnderGround);
    }

    public void ChangeState(MoleState newState)
    {
        StopCoroutine(Molestate.ToString());
        Molestate = newState;
        StartCoroutine(Molestate.ToString());
    }

    private IEnumerator UnderGround()
    {
        movement3D.MoveTo(Vector3.zero);
        transform.position = new Vector3(transform.position.x, transform.position.y, limitUnderZ);
        yield return null;
    }

    private IEnumerator OnGround()
    {
        movement3D.MoveTo(Vector3.zero);
        transform.position = new Vector3(transform.position.x, transform.position.y, limitOnZ);
        yield return new WaitForSeconds(waitTimeOnGround);
        ChangeState(MoleState.MoveDown);
    }

    private IEnumerator MoveUp()
    {
        movement3D.MoveTo(Vector3.back);

        while (true)
        {
            if (transform.position.z <= limitOnZ)
            {
                ChangeState(MoleState.OnGround);
            }
            yield return null;
        }
    }

    private IEnumerator MoveDown()
    {
        movement3D.MoveTo(Vector3.forward);

        while (true)
        {
            if (transform.position.z >= limitUnderZ)
            {
                ChangeState(MoleState.UnderGround);
            }
            yield return null;
        }
    }
}
