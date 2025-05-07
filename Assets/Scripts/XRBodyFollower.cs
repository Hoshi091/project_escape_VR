using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRBodyFollower : MonoBehaviour
{
    public Transform target; // XR Origin
    public float followSpeed = 20f;

    void FixedUpdate()
    {
        // Smooth follow position
        transform.position = Vector3.Lerp(transform.position, target.position, Time.fixedDeltaTime * followSpeed);
    }
}
