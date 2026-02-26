using UnityEngine;
using UnityEngine.InputSystem;


namespace Pedroca2005BR.DesignPatterns.FSM._Example
{
    public class CubeBehaviour : MonoBehaviour
    {
        public float speed = 5f;
        [SerializeField] Rigidbody _connectedBody;
        public Vector2 MoveInput { get; private set; }
        bool _spacePressed;

        private StateMachine stateMachine;

        private void Start()
        {
            stateMachine = new StateMachine();
            var blueState = new BlueState(this);
            var redState = new RedState(this);
            var purpleState = new PurpleState(this);

            stateMachine.AddTransition(blueState, redState, new FuncPredicate(() => NextState()));
            stateMachine.AddTransition(redState, purpleState, new FuncPredicate(() => NextState()));
            stateMachine.AddTransition(purpleState, blueState, new FuncPredicate(() => NextState()));

            stateMachine.SetState(blueState);
        }

        private void Update()
        {
            stateMachine.Update();
        }

        public void HandleMove()
        {
            if (MoveInput != Vector2.zero)
            {
                _connectedBody.MovePosition(transform.position + new Vector3(MoveInput.x * speed, MoveInput.y * speed, 0) * Time.fixedDeltaTime);
            }
        }

        public bool NextState()
        {
            if (_spacePressed)
            {
                _spacePressed = false;
                return true;
            }

            return false;
        }


        #region Input System

        public void OnMove(InputValue inputValue)
        {
            MoveInput = inputValue.Get<Vector2>();
        }

        public void OnJump(InputValue button)
        {
            _spacePressed = true;
            Debug.Log("Space Pressed");
        }

        #endregion
    }
}

