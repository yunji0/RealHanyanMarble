using System.Collections;
using UnityEngine;

public class HitProcess : MonoBehaviour
{
    [SerializeField]
    private ObjectDetector objectDetector;

    [SerializeField]
    private GameObject hitEffectPrefab;

    public int point = 0;

    private void Awake()
    {
        objectDetector.raycastEvent.AddListener(OnHit);
    }

    private void OnHit(Transform target)
    {
        if (target.CompareTag("Mole"))
        {
            BBFSM mole = target.GetComponent<BBFSM>();

            if (mole.Molestate == MoleState.UnderGround) return;
            point++;
            mole.ChangeState(MoleState.UnderGround);

            GameObject clone = Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);
            ParticleSystem.MainModule main = clone.GetComponent<ParticleSystem>().main;
            main.startColor = mole.GetComponent<MeshRenderer>().material.color;

        }
    }

    private void Update()
    {
        print(point);
    }
}