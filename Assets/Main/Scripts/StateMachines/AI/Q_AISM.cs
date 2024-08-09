using Qurino;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

namespace Quirino
{
    public class Q_AISM
    {
        #region FIELDS

        //private readonly Q_AI m_AI;
        //private Q_AIState m_currentState;

        private static Q_AIState m_idleState;
        private static Q_AIState m_patrolState;
        private static Q_AIState m_persuitState;
        private static Q_AIState m_fleeState;

        #endregion

        #region PROPERTIES

        /*private Q_AIState CurrentState //por que private
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
        }/**/

        public static Q_AIState IdleState { get { return m_idleState ??= new Q_AIStateIdle(); } }
        public static Q_AIState PatrolingState { get { return m_patrolState ??= new Q_AIStatePatrol(); } }
        public static Q_AIState PersuitState { get { return m_persuitState ??= new Q_AIStatePersuit(); } }
        public static Q_AIState FleeingState { get { return m_fleeState ??= new Q_AIStateFlee(); } }

        #endregion

        public Q_AISM()
        {

        }

        public void OnUpdate(Q_AI ai)
        {
            ai.m_state = ai.m_state.OnUpdate(ai);
        }
        public void OnFixedUpdate(Q_AI ai)
        {

            ai.m_state = ai.m_state.OnFixedUpdate(ai);
        }

        public void OnRender(Q_AI ai)
        {
            ai.m_state.OnRender(ai);
        }
    }
}