using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRRigController : MonoBehaviour
{
    public Transform headConstraint;
    public Vector3 headBodyOffset;

    public Transform[] vrTarget;
    public Transform[] rigTarget;
    public Vector3[] trackingPositionOffset;
    public Vector3[] trackingRotationOffset;

    public void Map()
    {
        for (int i = 0; i < 3; i++)
        {
            rigTarget[i].position = vrTarget[i].TransformPoint(trackingPositionOffset[i]);
            rigTarget[i].rotation = vrTarget[i].rotation * Quaternion.Euler(trackingRotationOffset[i]);
        }
    }

    void Start()
    {
        headBodyOffset = transform.position - headConstraint.position;
    }

    void LateUpdate()
    {
        transform.position = headConstraint.position + headBodyOffset;
        transform.forward = Vector3.ProjectOnPlane(headConstraint.up, Vector3.up).normalized;

        Map();
    }

}