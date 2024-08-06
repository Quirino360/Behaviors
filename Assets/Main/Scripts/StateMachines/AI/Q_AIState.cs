using Qurino;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quirino
{
    public abstract class Q_AIState
    {
        protected readonly Q_AI m_AI;
        protected readonly Q_AISM m_fsm;
        public Q_AIState(Q_AI ai, Q_AISM fsm)
        {
            m_AI = ai;
            m_fsm = fsm;
        }

        abstract public void OnEnter();
        abstract public Q_AIState OnUpdate();
        abstract public Q_AIState OnFixedUpdate();
        abstract public void OnExit();
        abstract public void OnRender();
    }
}