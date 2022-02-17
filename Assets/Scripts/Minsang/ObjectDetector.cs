using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ObjectDetector : MonoBehaviour
{
    [System.Serializable]
    public class RaycastEvent : UnityEvent<Transform> { }

    [HideInInspector]
    public RaycastEvent raycastEvent = new RaycastEvent();

    private Ray ray;
    private RaycastHit hit;

    public GameObject rHand;

    void Start()
    {

    }

    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.One))
        {
            ray = new Ray(rHand.transform.position, rHand.transform.forward);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                raycastEvent.Invoke(hit.transform);
            }
        }
    }
}
