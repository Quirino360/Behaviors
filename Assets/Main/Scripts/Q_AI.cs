using Quirino;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Xml;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.InputSystem.OnScreen.OnScreenStick;

namespace Qurino
{
    public class Q_AI : Q_Character
    {
        [Header("SteeringBehaviour")]

        Q_SteeringBehaviours m_steeringBehaviour = new Q_SteeringBehaviours();

        //[SerializeField] private float m_aceleration = 1.2f; // Nice To Have
        //[SerializeField] private float m_gravity = 2.0f; // Nice To Have
        [SerializeField, Range(0.0f, 1.0f)] private float m_mass = 0.5f; // 0 - 1 0 = nada de masa, 1 es masa absoluta

        [Header("Path")]
        [SerializeField] private Q_Path m_path;

        private Vector3 m_currentForce = Vector3.zero;
        private Vector3 m_oldForce = Vector3.zero;

        // Arrive 
        private bool HasArrived = false;
        private float ArriveDistance = 0.0f;
        private float ArriveRadio = 0.0f;

        protected override void Start()
        {
            base.Start();
            m_speed = 2.5f;
            m_steeringBehaviour.m_path = m_path;

        }


        protected override void Update()
        {
            base.Update();
            
            m_force = Vector3.zero;
            // force es la suma de las fuerzas;
            foreach (Q_Behaviour behaviours in m_beahviours)
            {
                var chacarter = behaviours.m_target.GetComponent<Q_Character>();
                Vector3 targetDir = Vector3.zero;
                if (chacarter)
                {
                    targetDir = behaviours.m_target.GetComponent<Q_Character>().m_direction;
                }

                m_force = m_steeringBehaviour.GetDirection(behaviours.m_target.transform.position, transform.position,
                    targetDir, behaviours.targetProyection, behaviours.m_inpetu, m_smallRadio, m_bigRadio, behaviours.m_currentBehaviour);


                /*if(behaviours.m_currentBehaviour == STEERING_BEHAVIOUR.PERSUIT)
                {
                    float distance = (behaviours.m_target.transform.position - this.transform.position).magnitude;
                    if (distance > behaviours.m_radio)// Si esta andro del radio de persuit
                    {

                    }
                }*/
                if (behaviours.m_currentBehaviour == STEERING_BEHAVIOUR.ARRIVE) // tomar en cuenta el arrive mas cercano
                {
                    ArriveDistance = (behaviours.m_target.transform.position - this.transform.position).magnitude;
                    if (ArriveDistance > m_bigRadio) // Si esta andro del radio de arrive
                    {
                        HasArrived = true;
                        ArriveRadio = m_bigRadio;
                    }

                }
            }

            m_currentForce = ((m_force * (1 - m_mass)) + (m_oldForce * m_mass));
            m_oldForce = m_currentForce;

            m_direction = m_currentForce.normalized;
            if (HasArrived == false)
            {
                transform.position += m_direction * m_speed * Time.deltaTime;
            }
            else
            {
                float ArriveSpeed = (ArriveDistance / ArriveRadio) * m_speed;
                transform.position += m_direction * ArriveSpeed * Time.deltaTime;
            }

        }

        // realForce = (force * (1-mass) + (oldForce * mass))transorm
        // old force = realForce 
    }
} // namespace