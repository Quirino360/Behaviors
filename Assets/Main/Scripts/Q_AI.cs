using Quirino;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Xml;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.InputSystem.OnScreen.OnScreenStick;

namespace Qurino
{
    [Serializable]
    public struct Q_Behaviour
    {
        public STEERING_BEHAVIOUR m_currentBehaviour;
        public GameObject m_target; //pos and dir, only if it has dir
        public float m_inpetu;
        public float m_radio;
        public float targetProyection;
    }

    public class Q_AI : Q_Character
    {
        [Header("SteeringBehaviour")]
        [SerializeField] private Q_Behaviour[] m_beahviours;
        Q_SteeringBehaviours m_steeringBehaviour = new Q_SteeringBehaviours();

        [Header ("Movement")]
        [SerializeField] private float m_speed = 1.5f;
        [SerializeField] private float m_aceleration = 1.2f;
        [SerializeField] private float m_gravity = 2.0f;
        [SerializeField, Range(0.0f, 1.0f)] private float m_mass = 0.5f; // 0 - 1 0 = nada de masa, 1 es masa absoluta

        private Vector3 m_force = Vector3.zero;
        private Vector3 m_currentForce = Vector3.zero;
        private Vector3 m_oldForce = Vector3.zero;

        // Arrive 
        private bool HasArrived = false;
        private float ArriveDistance = 0.0f;
        private float ArriveRadio = 0.0f;

        // Persuit
        private bool inPersuitRadio = false;


    void Start()
    {
        
    }

    
    void Update()
    {
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
                targetDir, behaviours.targetProyection, behaviours.m_inpetu, behaviours.m_radio, behaviours.m_currentBehaviour);
            

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
                if(ArriveDistance > behaviours.m_radio) // Si esta andro del radio de arrive
                {
                    HasArrived = true;
                    ArriveRadio = behaviours.m_radio;
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