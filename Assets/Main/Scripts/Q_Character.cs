using Quirino;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Qurino
{
    public class Q_Character : MonoBehaviour
    {
        [Serializable]
        protected struct Q_Behaviour
        {
            public STEERING_BEHAVIOUR m_currentBehaviour;
            public GameObject m_target; //pos and dir, only if it has dir
            public float m_inpetu;
            public float targetProyection;
        }

        [SerializeField] private Q_Bullet m_bullet;
        protected GameObject m_muzzle;
        protected GameObject m_shipSprite;


        private Vector3 direction = Vector3.zero;
        public Vector3 m_direction
        {
            get { return direction; }
            set { direction = value; }
        }

        private Vector3 force = Vector3.zero;
        public Vector3 m_force
        {
            get { return force; }
            set { force = value; }
        }

        private float speed = 10.0f;
        public float m_speed
        {
            get { return speed; }
            set { speed = value; }
        }

        private float boostSpeed = 1.0f;
        public float m_boostSpeed
        {
            get { return boostSpeed; }
            set { boostSpeed = value; }
        }

        private uint lives = 1;
        public uint m_lives
        {
            get { return lives; }
            set { lives = value; }
        }

        [SerializeField] protected Q_Behaviour[] m_beahviours;
        [SerializeField] protected float m_bigRadio;
        [SerializeField] protected float m_smallRadio;


        Q_Ring ring;


        protected virtual void Start()
        {
            ring = GetComponentInChildren<Q_Ring>();

            m_shipSprite = gameObject.transform.GetChild(0).gameObject;
            m_muzzle = m_shipSprite.gameObject.transform.GetChild(0).gameObject;


        }


        protected virtual void Update()
        {
            ring.DrawCircle(ring.smallCircle, 100, m_smallRadio);
            ring.DrawCircle(ring.bigCircle, 100, m_bigRadio);

            ring.DrawLine(ring.direction, transform.position, transform.position + m_direction);
            ring.DrawLine(ring.speed, transform.position, transform.position + m_force);
        }

        protected virtual void Shoot(Vector3 shootDir)
        {
            var bullet = Instantiate(m_bullet.gameObject, m_muzzle.transform.position, m_muzzle.transform.rotation);
            var bullSCpt = bullet.gameObject.GetComponent<Q_Bullet>();
            bullSCpt.m_direction = shootDir;
        }
    }
} // namespace