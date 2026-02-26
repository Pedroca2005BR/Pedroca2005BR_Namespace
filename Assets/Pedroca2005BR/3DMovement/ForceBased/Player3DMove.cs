using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Pedroca2005BR._3DMovement.ForceBased
{
    // Incomplete
    public class Player3DMove : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private Vector2 _moveInput;
        private Vector2 _lookInput;
        private bool _jumpInput;

        [Header("Movement Settings")]
        public float moveSpeed = 2f;
        public bool airControl = false;

        [Header("Jump Settings")]
        [SerializeField] Transform _groundCheck;
        public float groundCheckSize = 1.1f;
        [SerializeField] LayerMask _groundLayer;
        public float jumpForce = 5f;


        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (_jumpInput && IsGrounded())
            {
                Jump();
            }
        }

        private void FixedUpdate()
        {
            Walking();

            ControlDrag();
        }

        private void ControlDrag()
        {
            if (!airControl && !IsGrounded())
            {
                _rigidbody.linearDamping = 0.5f; // Reduces linear damping for better air control
                return;
            }
        }

        private void Walking()
        {
            if (!airControl && !IsGrounded()) return; // Returns if the player is not grounded to prevent mid-air control

            _rigidbody.linearDamping = 5f; // Increases linear damping to reduce sliding
            _rigidbody.AddForce(new Vector3(_moveInput.x * moveSpeed, 0, _moveInput.y * moveSpeed), ForceMode.VelocityChange);
        }

        void Jump()
        {
            _rigidbody.AddForceAtPosition(Vector3.up * jumpForce, transform.position, ForceMode.Impulse);
            _jumpInput = false;
        }

        bool IsGrounded()
        {
            return Physics.Raycast(_groundCheck.position, Vector3.down, groundCheckSize, _groundLayer);
        }

        #region Input System

        public void OnMove(InputValue inputValue)
        {
            _moveInput = inputValue.Get<Vector2>();
        }

        public void OnLook(InputValue inputValue)
        {
            _lookInput = inputValue.Get<Vector2>();
        }

        public void OnJump(InputValue button)
        {
            _jumpInput = true;
        }

        #endregion

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(_groundCheck.position, _groundCheck.position + Vector3.down * groundCheckSize);
        }
    }
}