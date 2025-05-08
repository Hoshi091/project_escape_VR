using UnityEngine;

public class XRPlayerColliderSync : MonoBehaviour
{
    public Transform cameraTransform;
    public CapsuleCollider capsule;

    void Update()
    {
        Vector3 center = transform.InverseTransformPoint(cameraTransform.position);
        capsule.center = new Vector3(center.x, capsule.height / 2f, center.z);
    }
}