using Unity.Android.Gradle.Manifest;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float gravity;

    [SerializeField] private Vector3 velocity;

    [SerializeField] private CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    public void ChangeGravityVelocity()
    {
        velocity.y = -2f;
    }
    
    public void ChangeSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    //public void PhypsiscMove(float horizontal, float vertical)
    //{
    //    Vector3 direction = (horizontal * transform.right + vertical * transform.forward).normalized * speed * Time.fixedDeltaTime;
    //    Vector3 newLinearVelocity = new Vector3(direction.x, rigi.linearVelocity.y, direction.z);
    //    rigi.linearVelocity = newLinearVelocity;
    //}

    public void PlayerMove(float horizontal, float vertical)
    {
        Vector3 direction = (horizontal * transform.right + vertical * transform.forward).normalized * speed * Time.deltaTime;
        characterController.Move(direction);
    }

    public void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    }

    //private void PlayerMovement(Vector3 normalizedDirection)
    //{
    //    float horizontal = Input.GetAxisRaw("Horizontal");
    //    float vertical = Input.GetAxisRaw("Vertical");
    //    Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized * speed * Time.fixedDeltaTime;
    //    //Vector3 direction = new Vector3(horizontal, 0f, vertical) * speed * Time.fixedDeltaTime;
    //    //Vector3 clampDirection = Vector3.ClampMagnitude(direction * speed * Time.fixedDeltaTime, speed * Time.fixedDeltaTime);
    //    transform.position += direction;
    //}
}
