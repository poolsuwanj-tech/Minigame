using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField]
    private float moveSpeed = 4f;

    [SerializeField]
    private float gravity = -20f;

    [Header("Camera")]
    [SerializeField]
    private Transform cameraHolder;

    [SerializeField]
    private float mouseSensitivity = 0.08f;

    private CharacterController controller;

    private float verticalVelocity;

    private float cameraPitch;

    private void Start()
    {
        controller =
            GetComponent<CharacterController>();

        Cursor.lockState =
            CursorLockMode.Locked;

        Cursor.visible =
            false;
    }

    private void Update()
    {
        Move();

        Look();
    }

    private void Move()
    {
        if (Keyboard.current == null)
        {
            return;
        }

        float horizontal = 0f;
        float vertical = 0f;

        if (Keyboard.current.wKey.isPressed)
        {
            vertical += 1f;
        }

        if (Keyboard.current.sKey.isPressed)
        {
            vertical -= 1f;
        }

        if (Keyboard.current.dKey.isPressed)
        {
            horizontal += 1f;
        }

        if (Keyboard.current.aKey.isPressed)
        {
            horizontal -= 1f;
        }

        Vector3 direction =
            transform.right * horizontal +
            transform.forward * vertical;

        direction =
            Vector3.ClampMagnitude(
                direction,
                1f
            );

        if (controller.isGrounded &&
            verticalVelocity < 0f)
        {
            verticalVelocity =
                -2f;
        }

        verticalVelocity +=
            gravity *
            Time.deltaTime;

        Vector3 movement =
            direction *
            moveSpeed;

        movement.y =
            verticalVelocity;

        controller.Move(
            movement *
            Time.deltaTime
        );
    }

    private void Look()
    {
        if (Mouse.current == null)
        {
            return;
        }

        Vector2 mouseDelta =
            Mouse.current.delta.ReadValue();

        float mouseX =
            mouseDelta.x *
            mouseSensitivity;

        float mouseY =
            mouseDelta.y *
            mouseSensitivity;

        // หมุนตัวผู้เล่นซ้าย-ขวา
        transform.Rotate(
            Vector3.up *
            mouseX
        );

        // หมุนกล้องขึ้น-ลง
        cameraPitch -=
            mouseY;

        cameraPitch =
            Mathf.Clamp(
                cameraPitch,
                -80f,
                80f
            );

        cameraHolder.localRotation =
            Quaternion.Euler(
                cameraPitch,
                0f,
                0f
            );
    }
}