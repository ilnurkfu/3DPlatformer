using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Character
{
    [SerializeField] private bool isGrounded;
    [SerializeField] private bool isPause;

    [SerializeField] private float reycastDistance;
    [SerializeField] private float radius;
    [SerializeField] private float startRadius;

    [SerializeField] private LayerMask layer;

    [SerializeField] private Transform groundCheck;

    [SerializeField] private Movement movement;

    [SerializeField] private CameraRotation cameraRotation;

    [SerializeField] private PlayerInput playerInput;

    [SerializeField] private UISwitcher uISwitcher;

    private void Awake()
    {
        movement = GetComponent<Movement>();
        cameraRotation = GetComponentInChildren<CameraRotation>();
        playerInput = GetComponent<PlayerInput>();
    }

    private void Start()
    {
        startRadius = radius;
    }

    private void Update()
    {
        if(isPause == false)
        {
            playerInput.MouseInput();
            playerInput.KeyBoardInput();

            if (IsGroundedWithSphere() == true)
            {
                movement.ChangeGravityVelocity();
                if (playerInput.JumpInput())
                {
                    movement.Jump();
                }
            }

            movement.PlayerMove(playerInput.Horizontal, playerInput.Vertical);
            cameraRotation.RotateCamera(playerInput.MouseX, playerInput.MouseY);
        }

        if (playerInput.PauseInput())
        {
            uISwitcher.SwitchPauseMenu();
            PauseSwitch();
        }
    }

    //private void FixedUpdate()
    //{
    //    movement.PhypsiscMove(playerInput.Horizontal, playerInput.Vertical);
    //}

    public void PauseSwitch()
    {
        isPause = uISwitcher.GetPauseMenuStatus();
    }

    public override void Resize(float newMultiplaer)
    {
        base.Resize(newMultiplaer);
        radius = (startRadius + movement.Controller.skinWidth) * newMultiplaer;
        reycastDistance = (startRadius + movement.Controller.skinWidth) * newMultiplaer;
    }

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

    protected override void Died()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
