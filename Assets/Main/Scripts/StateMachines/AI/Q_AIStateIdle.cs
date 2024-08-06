using Qurino;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quirino
{
    public class Q_AIStateIdle : Q_AIState
    {
        public Q_AIStateIdle(Q_AI player, Q_AISM fsm) : base(player, fsm)
        {

        }

        public override void OnEnter()
        {

        }

        public override Q_AIState OnUpdate()
        {

            return m_fsm.IdleState;
        }

        public override Q_AIState OnFixedUpdate()
        {
            return m_fsm.IdleState;
        }

        public override void OnExit()
        {

        }
        public override void OnRender()
        {

        }
    }
}