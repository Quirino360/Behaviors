using Quirino;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.InputSystem;



namespace Qurino
{
    public class Q_Player : Q_Character
    {

        private GameObject childGO;
        [SerializeField] private Camera cam;

        protected GameObject Muzzle;

        private PlayerController input = null;
        public PlayerController m_input
        {  get { return input; } }

        private Vector2 movement = Vector2.zero;

        private Vector3 mouseDir = Vector3.zero;
        public Vector3 m_mouseDir
        {  
            get { return mouseDir; } 
            set { mouseDir = value; }
        }


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

            input.Player.Boost.performed += OnBoostPerfomed;
            input.Player.Boost.canceled += OnBoostCanceled;

            input.Player.Shoot.performed += OnShoot;

        }

        private void OnDisable()
        {
            input.Disable();
            input.Player.Movement.performed -= OnMovementPerfomed;
            input.Player.Movement.canceled -= OnMovementCanceled;

            input.Player.Boost.performed -= OnBoostPerfomed;
            input.Player.Boost.canceled -= OnBoostCanceled;

            input.Player.Shoot.performed -= OnShoot;

        }

        protected override void Start()
        {
            base.Start();

            m_lives = 5;


            childGO = transform.GetChild(0).gameObject;
            if (!childGO)
            {

            }

            Muzzle = ShipSprite.gameObject.transform.GetChild(0).gameObject;
        }

        // Update is called once per frame
        protected override void Update()
        {
            base.Update();

           
            Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            m_mouseDir = mousePos - transform.position;

            float rotz = Mathf.Atan2(m_mouseDir.y, m_mouseDir.x) * Mathf.Rad2Deg;

            childGO.transform.rotation = Quaternion.Euler(0, 0, rotz - 90);

        }

        public void Move()
        {
            m_force = m_direction * m_speed * m_boostSpeed * Time.deltaTime;
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

        private void OnBoostPerfomed(InputAction.CallbackContext value)
        {
            m_boostSpeed = 1.25f;
        }

        private void OnBoostCanceled(InputAction.CallbackContext value)
        {
            m_boostSpeed = 1.0f;
        }

        private void OnShoot(InputAction.CallbackContext value)
        {
            Shoot(m_mouseDir);
        }


    }
}
