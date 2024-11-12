using Unity.Android.Gradle.Manifest;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpHeight;

    [SerializeField] private Rigidbody rigi;

    private void Awake()
    {
        rigi = GetComponent<Rigidbody>();
    }

    public void ChangeSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    public void PhypsiscMove(float horizontal, float vertical)
    {
        Vector3 direction = (horizontal * transform.right + vertical * transform.forward).normalized * speed * Time.fixedDeltaTime;
        Vector3 newLinearVelocity = new Vector3(direction.x, rigi.linearVelocity.y, direction.z);
        rigi.linearVelocity = newLinearVelocity;
    }

    public void Jump()
    {
        rigi.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
    }

    private void PlayerMovement(Vector3 normalizedDirection)
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized * speed * Time.fixedDeltaTime;
        //Vector3 direction = new Vector3(horizontal, 0f, vertical) * speed * Time.fixedDeltaTime;
        //Vector3 clampDirection = Vector3.ClampMagnitude(direction * speed * Time.fixedDeltaTime, speed * Time.fixedDeltaTime);
        transform.position += direction;
    }
}
