using System.Collections;
using UnityEngine;

public class BBSpawner : MonoBehaviour
{
    [SerializeField]
    private BBFSM[] moles;

    [SerializeField]
    private float spawnTime;

    public HitProcess hitProcess;

    public int gameEndPoint;
    private bool isGame = true;

    public void Start()
    {
        StartCoroutine("SpawnMole");
    }

    private void Update()
    {
        if (hitProcess.point >= gameEndPoint)
        {
            isGame = false;
        }
    }

    private IEnumerator SpawnMole()
    {
        while (isGame)
        {
            int index = Random.Range(0, moles.Length);
            moles[index].ChangeState(MoleState.MoveUp);

            yield return new WaitForSeconds(spawnTime);
        }
    }
}
