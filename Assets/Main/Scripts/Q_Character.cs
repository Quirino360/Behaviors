using Quirino;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Qurino { 
public class Q_Character : MonoBehaviour
{
    [Serializable] protected struct Q_Behaviour
    {
        public STEERING_BEHAVIOUR m_currentBehaviour;
        public GameObject m_target; //pos and dir, only if it has dir

        public float targetProyection;
    }

    [SerializeField] protected Q_Behaviour[] m_beahviours;

    [SerializeField] protected float m_bigRadio;
    [SerializeField] protected float m_smallRadio;

    Q_Ring ring;


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



    protected virtual void Start()
    {
        ring = GetComponentInChildren<Q_Ring>();
    }


    protected virtual void Update()
    {
        ring.DrawCircle(ring.smallCircle, 100, m_smallRadio);
        ring.DrawCircle(ring.bigCircle, 100, 5);

        ring.DrawLine(ring.direction, transform.position, transform.position + m_direction);
        ring.DrawLine(ring.speed, transform.position, transform.position + m_force);
    }
}
} // namespace