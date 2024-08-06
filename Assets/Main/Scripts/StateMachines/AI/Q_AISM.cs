using Qurino;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quirino
{
    public class Q_AISM
    {
        #region FIELDS

        private readonly Q_AI m_AI;
        private Q_AIState m_currentState;

        private Q_AIState m_idleState;
        private Q_AIState m_patrolState;
        private Q_AIState m_persuitState;
        private Q_AIState m_fleeState;

        #endregion

        #region PROPERTIES

        private Q_AIState CurrentState //por que private
        {
            get { return m_currentState; }
            set
            {
                if (value != m_currentState)
                {
                    //if (_currentState != null)
                    //{
                    //	_currentState.OnExit();
                    //}
                    m_currentState?.OnExit();
                    m_currentState = value;
                    m_currentState.OnEnter();
                }
            }
        }

        public Q_AIState IdleState
        {
            get
            {
                return m_idleState ??= new Q_AIStateIdle(m_AI, this);
            }
        }
        public Q_AIState PatrolingState { get { return m_patrolState ??= new Q_AIStatePatrol(m_AI, this); } }
        public Q_AIState PersuitState { get { return m_persuitState ??= new Q_AIStatePersuit(m_AI, this); } }
        public Q_AIState FleeingState { get { return m_fleeState ??= new Q_AIStateFlee(m_AI, this); } }


        #endregion

        public Q_AISM(Q_AI ai)
        {
            m_AI = ai;

            CurrentState = IdleState;
        }

        public void OnUpdate()
        {
            CurrentState = CurrentState.OnUpdate();
        }

        public void OnFixedUpdate()
        {

            CurrentState = CurrentState.OnFixedUpdate();
        }

        public void OnRender()
        {
            m_currentState.OnRender();
        }
    }
}