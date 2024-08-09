using Qurino;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

namespace Quirino
{
    public abstract class Q_AIState
    {
        protected readonly Q_AISM m_fsm;


        public Q_AIState()
        {
        }

        abstract public void OnEnter();
        abstract public Q_AIState OnUpdate(Q_AI ai);
        abstract public Q_AIState OnFixedUpdate(Q_AI ai);
        abstract public void OnExit();
        abstract public void OnRender(Q_AI ai);
    }
}