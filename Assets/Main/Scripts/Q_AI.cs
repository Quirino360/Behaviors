using Quirino;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

namespace Qurino
{
    [Serializable]
    public struct Q_Behaviour
    {
        public STEERING_BEHAVIOUR m_currentBehaviour;
        public Transform m_target;
        public float m_inpetu;
        public float m_radio;

    }

    public class Q_AI : MonoBehaviour
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

    
    void Start()
    {
        
    }

    
    void Update()
    {
        m_force = Vector3.zero;
        // force es la suma de las fuerzas;
        foreach (Q_Behaviour behaviours in m_beahviours)
        {

            m_force += m_steeringBehaviour.GetDirection(behaviours.m_target.position, transform.position,
                behaviours.m_inpetu, behaviours.m_radio, behaviours.m_currentBehaviour);
        }

        m_currentForce = ((m_force * (1 - m_mass)) + (m_oldForce * m_mass));
        m_oldForce = m_currentForce;


        transform.position += m_currentForce.normalized * m_speed * Time.deltaTime;


    }

    // realForce = (force * (1-mass) + (oldForce * mass))transorm
    // old force = realForce 
}
} // namespace