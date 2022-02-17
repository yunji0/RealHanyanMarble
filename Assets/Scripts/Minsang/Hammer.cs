using System.Collections;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    [SerializeField]
    private float onZ;

    [SerializeField]
    private float underZ;

    [SerializeField]
    private ObjectDetector objectDetector;
    private Movement3D movement3D;

    public int point = 0;

    private void Awake()
    {
        movement3D = GetComponent<Movement3D>();
        objectDetector.raycastEvent.AddListener(OnHit);
    }

    private void OnHit(Transform target)
    {
        if (target.CompareTag("Mole"))
        {
            BBFSM mole = target.GetComponent<BBFSM>();

            if (mole.Molestate == MoleState.UnderGround) return;

            transform.position = new Vector3(target.position.x, target.position.y, underZ);
            point++;
            mole.ChangeState(MoleState.UnderGround);
            StartCoroutine("MoveUp");
        }
    }

    private IEnumerator MoveUp()
    {
        movement3D.MoveTo(Vector3.back);

        while (true)
        {
            if (transform.position.z <= onZ)
            {
                movement3D.MoveTo(Vector3.zero);
                break;
            }
            yield return null;
        }
    }

    private void Update()
    {
        print(point);
    }
}