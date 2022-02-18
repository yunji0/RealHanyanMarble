using System.Collections;
using UnityEngine;

public class HitProcess : MonoBehaviour
{
    [SerializeField]
    private ObjectDetector objectDetector;

    [SerializeField]
    private GameObject hitEffectPrefab;

    private AudioSource audioSource;

    public int point = 0;

    private void Awake()
    {
        objectDetector.raycastEvent.AddListener(OnHit);
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    private void OnHit(Transform target)
    {
        if (target.CompareTag("Mole"))
        {
            BBFSM mole = target.GetComponent<BBFSM>();

            if (mole.Molestate == MoleState.UnderGround) return;
            point++;
            mole.ChangeState(MoleState.UnderGround);

            transform.position = new Vector3(target.position.x, target.position.y, target.position.z);
            GameObject clone = Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);
            ParticleSystem.MainModule main = clone.GetComponent<ParticleSystem>().main;
            main.startColor = mole.GetComponent<MeshRenderer>().material.color;

            this.audioSource.Play();
        }
    }

    /*
    private void Update()
    {
        print(point);
    }
    */
}