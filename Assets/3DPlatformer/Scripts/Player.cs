using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Player : MonoBehaviour
{
    [SerializeField] private bool isGrounded;

    [SerializeField] private float reycastDistance;
    [SerializeField] private float radius;

    [SerializeField] private LayerMask layer;

    [SerializeField] private Transform groundCheck;

    [SerializeField] private Movement movement;

    [SerializeField] private CameraRotation cameraRotation;

    [SerializeField] private PlayerInput playerInput;

    private void Awake()
    {
        movement = GetComponent<Movement>();
        cameraRotation = GetComponentInChildren<CameraRotation>();
        playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        playerInput.MouseInput();
        playerInput.KeyBoardInput();

        if (IsGroundedWithSphere() == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                movement.Jump();
            }
        }

        cameraRotation.RotateCamera(playerInput.MouseX, playerInput.MouseY);
    }

    private void FixedUpdate()
    {
        if(isGrounded == true)
        {

            movement.PhypsiscMove(playerInput.Horizontal, playerInput.Vertical);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<TriggerObject>() != null)
        {
            TriggerObject currentTrigger = other.GetComponent<TriggerObject>();
            if(currentTrigger.IsActive == true)
            {
                Resize();
                currentTrigger.Deactivated();
            }

            GetComponent<MeshRenderer>().material.color = Color.green;
        }
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    Debug.Log("OnTriggerStay");
    //}

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<TriggerObject>() != null)
        {
            GetComponent<MeshRenderer>().material.color = Color.gray;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<CollisionObject>() != null)
        {
            collision.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
            movement.ChangeSpeed(collision.gameObject.GetComponent<CollisionObject>().BonusSpeed);
        }
    }

    //private void OnCollisionStay(Collision collision)
    //{
    //    if (collision.gameObject.GetComponent<CollisionObject>() != null)
    //    {
    //        Debug.Log("OnCollisionStay");
    //    }
    //}

    //private void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.GetComponent<CollisionObject>() != null)
    //    {

    //    }
    //}

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

    private void Resize()
    {
        transform.localScale *= 2f;
        radius *= 2f;
        reycastDistance *= 2f;
    }
}
