using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField]
    private float walkSpeed = 4f;

    [SerializeField]
    private float runSpeed = 7f;

    [SerializeField]
    private float rotationSpeed = 10f;

    [Header("Jump")]
    [SerializeField]
    private float jumpHeight = 1.5f;

    [SerializeField]
    private float gravity = -20f;

    private CharacterController controller;

    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction sprintAction;

    private Vector3 verticalVelocity;

    private void Start()
    {
        controller =
            GetComponent<CharacterController>();

        moveAction =
            InputSystem.actions.FindAction("Move");

        jumpAction =
            InputSystem.actions.FindAction("Jump");

        sprintAction =
            InputSystem.actions.FindAction("Sprint");
    }

    private void Update()
    {
        Move();
        JumpAndGravity();
    }

    private void Move()
    {
        Vector2 input =
            moveAction.ReadValue<Vector2>();

        Vector3 direction =
            new Vector3(
                input.x,
                0f,
                input.y
            );

        if (direction.magnitude < 0.1f)
        {
            return;
        }

        direction.Normalize();

        float speed =
            walkSpeed;

        if (sprintAction.IsPressed())
        {
            speed =
                runSpeed;
        }

        controller.Move(
            direction *
            speed *
            Time.deltaTime
        );

        Quaternion targetRotation =
            Quaternion.LookRotation(
                direction
            );

        transform.rotation =
            Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                rotationSpeed *
                Time.deltaTime
            );
    }

    private void JumpAndGravity()
    {
        if (controller.isGrounded &&
            verticalVelocity.y < 0f)
        {
            verticalVelocity.y =
                -2f;
        }

        if (jumpAction.WasPressedThisFrame() &&
            controller.isGrounded)
        {
            verticalVelocity.y =
                Mathf.Sqrt(
                    jumpHeight *
                    -2f *
                    gravity
                );
        }

        verticalVelocity.y +=
            gravity *
            Time.deltaTime;

        controller.Move(
            verticalVelocity *
            Time.deltaTime
        );
    }
}
