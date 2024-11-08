using UnityEngine;

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

    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * sensivity;
        float mouseY = Input.GetAxisRaw("Mouse Y") * sensivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, minVerticalAngle, maxVerticalAngle);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerTransform.Rotate(Vector3.up, mouseX);
    }
}
