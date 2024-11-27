using UnityEngine;

public class Player : Character
{
    [SerializeField] private bool isGrounded;

    [SerializeField] private float reycastDistance;
    [SerializeField] private float radius;
    [SerializeField] private float health;

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
            movement.ChangeGravityVelocity();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                movement.Jump();
            }
        }

        movement.PlayerMove(playerInput.Horizontal, playerInput.Vertical);
        cameraRotation.RotateCamera(playerInput.MouseX, playerInput.MouseY);
    }

    //private void FixedUpdate()
    //{
    //    movement.PhypsiscMove(playerInput.Horizontal, playerInput.Vertical);
    //}

    public override void Resize(float newMultiplaer)
    {
        base.Resize(newMultiplaer);
        radius *= newMultiplaer;
        reycastDistance *= newMultiplaer;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<ITriggerObject>() != null)
        {
            other.GetComponent<ITriggerObject>().TriggerAction(this);
        }

        //Debug.Log("ITriggerObject is empty:= " + other.GetComponent<ITriggerObject>() != null);
        //if (other.GetComponent<ITriggerObject>() != null)
        //{
        //    ITriggerObject currentTriggerObject = other.GetComponent<ITriggerObject>();
        //    currentTriggerObject.TriggerAction();
        //}
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    Debug.Log("OnTriggerStay");
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //}

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.GetComponent<Door>())
        {
            hit.gameObject.GetComponent<Door>().ColorCheck(gameObject.GetComponent<MeshRenderer>().material.color);
        }
    }

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

    public void ApplyDamage(int newDamage)
    {
        health = Mathf.Max(0, health - newDamage);
        if(health == 0)
        {
            Died();
        }
    }

    private void Died()
    {
        Debug.Log("Потрачено");
    }
}
