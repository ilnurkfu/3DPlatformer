using Unity.Android.Gradle.Manifest;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class Movement : MonoBehaviour
{
    [SerializeField] private bool isGrounded;

    [SerializeField] private float speed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float reycastDistance;
    [SerializeField] private float radius;

    [SerializeField] private LayerMask layer;

    [SerializeField] private Transform groundCheck;

    [SerializeField] private Rigidbody rigi;

    private void Awake()
    {
        rigi = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (IsGroundedWithSphere() == true)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        Vector3 clampDirection = Vector3.ClampMagnitude(direction * speed * Time.fixedDeltaTime, speed * Time.fixedDeltaTime);
        transform.position += clampDirection;
    }



    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigi.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }
    }

    private bool IsGroundedWithRaycast()
    {
        isGrounded = Physics.Raycast(groundCheck.position, Vector3.down, reycastDistance, layer);
        Debug.Log("Raycast grounded=: " + Physics.Raycast(groundCheck.position, Vector3.down, reycastDistance, layer));
        return isGrounded;
    }

    private bool IsGroundedWithSphere()
    {
        isGrounded = Physics.OverlapSphere(groundCheck.position, radius, layer).Length > 0;
        Debug.Log("Spher grounded=: " + (Physics.OverlapSphere(groundCheck.position, radius, layer).Length > 0));
        return isGrounded;
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, radius);

            Gizmos.color = Color.blue;
            Gizmos.DrawLine(groundCheck.position, groundCheck.position + Vector3.down * reycastDistance);
        }
    }
}
