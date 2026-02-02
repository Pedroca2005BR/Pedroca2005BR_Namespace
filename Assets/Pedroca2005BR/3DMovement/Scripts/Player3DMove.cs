using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player3DMove : MonoBehaviour
{
    [Header("Input Actions")]
    public InputActionAsset inputActions;

    private InputAction _moveAction;
    private InputAction _jumpAction;
    private InputAction _sprintAction;
    private InputAction _lookAction;

    private Rigidbody _rigidbody;
    private Vector2 _moveInput;
    private Vector2 _lookInput;

    [Header("Jump Settings")]
    [SerializeField] Transform _groundCheck;
    [SerializeField] LayerMask _groundLayer;
    public float jumpForce = 5f;

    private void OnEnable()
    {
        inputActions.FindActionMap("Player").Enable();
    }

    private void OnDisable()
    {
        inputActions.FindActionMap("Player").Disable();
    }

    private void Start()
    {
        _moveAction = InputSystem.actions.FindAction("Move");
        _jumpAction = InputSystem.actions.FindAction("Jump");
        _sprintAction = InputSystem.actions.FindAction("Sprint");
        _lookAction = InputSystem.actions.FindAction("Look");

        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _moveInput = _moveAction.ReadValue<Vector2>();
        _lookInput = _lookAction.ReadValue<Vector2>();

        if (_jumpAction.IsPressed() && IsGrounded())
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        Walking();
    }

    private void Walking()
    {
        _rigidbody
    }

    void Jump()
    {
        _rigidbody.AddForceAtPosition(Vector3.up * jumpForce, transform.position, ForceMode.Impulse);
    }

    bool IsGrounded()
    {
        return Physics.Raycast(_groundCheck.position, Vector3.down, 1.1f, _groundLayer);
    }
}
