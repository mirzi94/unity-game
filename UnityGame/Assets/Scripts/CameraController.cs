using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public bool lookAtTarget= false;

    private void Start()
    {
        offset = transform.position - target.transform.position;
    }

    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.Slerp(transform.position, desiredPosition, smoothSpeed);

        if (lookAtTarget)
        {
            transform.LookAt(target);
        }
    }

}
