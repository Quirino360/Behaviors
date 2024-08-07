using Quirino;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



namespace Qurino
{
    public class Q_Player : Q_Character
    {
        private PlayerController input = null;
        public PlayerController m_input
        {  get { return input; } }

        private Vector2 movement = Vector2.zero;

        private Q_PlayerState state = new Q_PlayerStateIdle();
        public Q_PlayerState m_state
        {
            get { return state; }
            set
            {
                if (value != state)
                {
                    // if (_currentState != null)
                    // {
                    // 	_currentState.OnExit();
                    // }
                    state?.OnExit();
                    state = value;
                    state.OnEnter();
                }
            }
        }/**/

        private void Awake()
        {
            input = new PlayerController();
        }

        private void OnEnable()
        {
            input.Enable();
            input.Player.Movement.performed += OnMovementPerfomed;
            input.Player.Movement.canceled += OnMovementCanceled;
        }

        private void OnDisable()
        {
            input.Disable();
            input.Player.Movement.performed -= OnMovementPerfomed;
            input.Player.Movement.canceled -= OnMovementCanceled;
        }

        protected override void Start()
        {
            base.Start();

        }

        // Update is called once per frame
        protected override void Update()
        {
            base.Update();
            m_force = m_direction * m_speed * Time.deltaTime;
            transform.position += m_force;
        }

        private void OnMovementPerfomed(InputAction.CallbackContext value)
        {
            m_direction = value.ReadValue<Vector2>();
            m_direction.Normalize();
        }

        private void OnMovementCanceled(InputAction.CallbackContext value)
        {
            m_direction = Vector2.zero;
        }
    }
}
