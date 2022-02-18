using System.Collections;
using UnityEngine;

public class BBSpawner : MonoBehaviour
{
    [SerializeField]
    private BBFSM[] moles;

    [SerializeField]
    private float spawnTime;

    public HitProcess hitProcess;
    public MoleDialogue moleDialogue;

    public int gameEndPoint;
    public bool isGame = true;

    //public GameObject trophy;

    public void Start()
    {
        //StartCoroutine("SpawnMole");
    }

    private void Update()
    {
        if(moleDialogue.countDialogue >= 2)
        {
            StartCoroutine("SpawnMole");
        }

        if (hitProcess.point >= gameEndPoint)
        {
            isGame = false;
            //trophy.gameObject.SetActive(true);
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
