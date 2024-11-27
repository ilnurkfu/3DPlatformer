using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private float sensivity;
    [SerializeField] private float minVerticalAngle;
    [SerializeField] private float maxVerticalAngle;
    [SerializeField] private float xRotation;

    [SerializeField] private Transform playerTransform;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void RotateCamera(float mouseX, float mouseY)
    {
        mouseX = mouseX * sensivity;
        mouseY = mouseY * sensivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, minVerticalAngle, maxVerticalAngle);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerTransform.Rotate(Vector3.up, mouseX);
    }
}
