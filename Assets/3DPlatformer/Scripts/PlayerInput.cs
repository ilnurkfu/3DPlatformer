using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float horizontal;
    [SerializeField] private float vertical;
    [SerializeField] private float mouseX;
    [SerializeField] private float mouseY;

    public float Horizontal
    {
        get
        {
            return horizontal;
        }
    }

    public float Vertical
    {
        get
        {
            return vertical;
        }
    }

    public float MouseX
    {
        get
        {
            return mouseX;
        }
    }

    public float MouseY
    {
        get
        {
            return mouseY;
        }
    }

    public void KeyBoardInput()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    public void MouseInput()
    {
        mouseX = Input.GetAxisRaw("Mouse X");
        mouseY = Input.GetAxisRaw("Mouse Y");
    }

    public bool JumpInput()
    {
       return Input.GetKeyDown(KeyCode.Space);
    }

    public bool PauseInput()
    {
       return Input.GetKeyDown(KeyCode.E);
    }
}
