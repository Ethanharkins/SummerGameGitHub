using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float lookSpeed = 2.0f;
    public float jumpForce = 5.0f;
    public Camera playerCamera;

    private CharacterController characterController;
    private Vector3 moveDirection;
    private float gravity = 9.81f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        LookAround();
        Move();
    }

    void LookAround()
    {
        float horizontal = Input.GetAxis("Mouse X") * lookSpeed;
        float vertical = Input.GetAxis("Mouse Y") * lookSpeed;

        transform.Rotate(0, horizontal, 0);
        playerCamera.transform.Rotate(-vertical, 0, 0);
    }

    void Move()
    {
        if (characterController.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= moveSpeed;

            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
