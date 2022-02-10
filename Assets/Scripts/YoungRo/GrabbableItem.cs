using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableItem : OVRGrabbable
{

    [SerializeField] private Material _isGrabbableMAT;
    private Material _originalMat;
    private Renderer _renderer;

    protected override void Start()
    {
        base.Start();
        _renderer = GetComponent<Renderer>();
        _originalMat = _renderer.material;
    }

    public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        base.GrabBegin(hand, grabPoint);
        _renderer.material = _isGrabbableMAT;
    }

    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        base.GrabEnd(linearVelocity, angularVelocity);
        _renderer.material = _originalMat;
    }

}
