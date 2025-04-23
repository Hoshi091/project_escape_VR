using UnityEngine;

public class XRPlayerMovement : MonoBehaviour
{
    public Transform xrCamera;
    public float gravity = -9.81f;
    public float additionalHeight = 0.2f;

    private CharacterController characterController;
    private float fallingSpeed;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        if (xrCamera == null)
        {
            Debug.LogError("Assign your XR camera to the script!");
        }
    }

    void Update()
    {
        SyncCharacterHeightToHead();
        ApplyGravity();
    }

    void SyncCharacterHeightToHead()
    {
        float headHeight = Mathf.Clamp(xrCamera.localPosition.y, 1f, 2f);
        characterController.height = headHeight + additionalHeight;

        Vector3 center = transform.InverseTransformPoint(xrCamera.position);
        characterController.center = new Vector3(center.x, characterController.height / 2f, center.z);
    }

    void ApplyGravity()
    {
        if (!characterController.isGrounded)
        {
            fallingSpeed += gravity * Time.deltaTime;
            characterController.Move(Vector3.up * fallingSpeed * Time.deltaTime);
        }
        else
        {
            fallingSpeed = 0f;
        }
    }
}
