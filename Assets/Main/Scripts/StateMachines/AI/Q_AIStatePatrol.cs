using Quirino;
using Qurino;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86;

namespace Quirino
{
    public class Q_AIStatePatrol : Q_AIState
    {
        public Q_AIStatePatrol(Q_AI player, Q_AISM fsm) : base(player, fsm)
        {

        }

        public override void OnEnter()
        {

        }

        public override Q_AIState OnUpdate()
        {
            
            return m_fsm.PatrolingState;
        }

        public override Q_AIState OnFixedUpdate()
        {
            return m_fsm.PatrolingState;
        }

        public override void OnExit()
        {

        }
        public override void OnRender()
        {

        }
    }
}