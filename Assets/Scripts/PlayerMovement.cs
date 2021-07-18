using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController CharacterController;

    Controller controls;

    Vector2 move;
    Vector3 velocity;

    public float jumpHeight = 3f;
    public float gravity =  -9.8f;
    public float groundDistance = 0.4f;
    public float walkSpeed = 10f;
    public float runSpeed = 16f;
    float moveSpeed;

    public Transform groundCheck;
    public LayerMask groundMask;

    private void Awake()
    {
        controls = new Controller();

        controls.Movement.Move.performed += cts => move = cts.ReadValue<Vector2>();
        controls.Movement.Move.canceled += cts => move = Vector2.zero;

        controls.Movement.Jump.performed += cts => Jump();

        controls.Movement.Run.performed += cts => moveSpeed = runSpeed;
        controls.Movement.Run.canceled += cts => moveSpeed = walkSpeed;

       // groundMask = LayerMask.NameToLayer("Ground");
        groundMask = LayerMask.GetMask("Ground");
    }

    private void Start()
    {
        CharacterController = GetComponent<CharacterController>();
        moveSpeed = walkSpeed;
        groundCheck = transform.Find("GroundCheck");
    }

    void Update()
    {
        if (isGrounded() && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        Vector3 move3 = transform.right * move.x + transform.forward * move.y;

        CharacterController.Move(move3 * moveSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        CharacterController.Move(velocity * Time.deltaTime);
    }

    void Jump()
    {
        if (isGrounded())
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    }

    bool isGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }

    #region ON_ENABLE/DISABLE
    private void OnEnable()
    {
        controls.Movement.Enable();
    }

    private void OnDisable()
    {
        controls.Movement.Disable();
    }
    #endregion

}
