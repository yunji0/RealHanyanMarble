using System.Collections;
using UnityEngine;

public class Y_BBSpawner : MonoBehaviour
{
    [SerializeField]
    private Y_BBFSM[] moles;

    [SerializeField]
    private float spawnTime;

    public Y_HitProcess Y_HitProcess;

    public int gameEndPoint;
    public bool isGame = true;

    //public GameObject trophy;

    public void Start()
    {
        StartCoroutine("Y_SpawnMole");
    }

    private void Update()
    {
        if (Y_HitProcess.point >= gameEndPoint)
        {
            isGame = false;
            //trophy.gameObject.SetActive(true);
        }
    }

    private IEnumerator Y_SpawnMole()
    {
        while (isGame)
        {
            int index = Random.Range(0, moles.Length);
            moles[index].ChangeState(Y_MoleState.MoveUp);

            yield return new WaitForSeconds(spawnTime);
        }
    }
}
